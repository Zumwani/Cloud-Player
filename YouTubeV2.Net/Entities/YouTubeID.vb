Imports System.Xml

''' <summary>Represents an id on YouTube, supports video, playlist and user ids.</summary>
Public Class YouTubeID

    ''' <summary>Specifies the id length for a video on YouTube.</summary>
    Public Const VideoIDLength As Integer = 11
    ''' <summary>Specifies the id length for a playlist on YouTube.</summary>
    Public Const PlaylistIDLength As Integer = 34
    ' ''' <summary>Specifies the id length for a user on YouTube.</summary>
    'Public Const ChannelIDLength As Integer = 24 '22

#Region "Constructors"

    Private Sub New(IDString As String, Optional Type As IDType = IDType.Unknown)
        Me.ID = IDString
        Me._Type = Type
    End Sub

    ''' <summary>Creates a YouTube id from a video, playlist or channel url.</summary>
    Public Shared Function FromUri(Uri As Uri) As YouTubeID

        If Uri.Segments.Contains("watch") Then
            For Each s In Uri.Query.Split({"&"c, "?"c})
                If s.Split("=").First = "v" Then
                    Return YouTubeID.FromIDString(s.Split("=").Last, IDType.Video)
                End If
            Next
        ElseIf Uri.Query.Contains("list=") Then
            For Each s In Uri.Query.Split({"&"c, "?"c})
                If s.Split("=").First = "list" Then
                    Return YouTubeID.FromIDString(s.Split("=").Last, IDType.Playlist)
                End If
            Next
        ElseIf Uri.OriginalString.Contains("api") Then

            If Uri.OriginalString.Contains("playlists") Then
                Return FromIDString(Uri.AbsolutePath.Split("/").Last, IDType.Playlist)
            ElseIf Uri.OriginalString.Contains("users") Then
                Return FromIDString(Uri.AbsolutePath.Split("/").Last, IDType.Channel)
            End If

        Else

            Dim r As New System.Text.RegularExpressions.Regex("^(http(s?):\/\/)?(www\.)?youtu(be)?\.([a-z])+\/((channel/)|(user/))(.*?)/(.*?)(&(.)*)?$")
            Dim m As System.Text.RegularExpressions.Match = r.Match(Uri.OriginalString)

            If m.Success And m.Groups.Count >= 9 Then
                Return YouTubeID.FromIDString(m.Groups(9).Value, IDType.Channel)
            End If

        End If

        'Could not get id from uri
        Throw New ArgumentException("Could not parse id from the url '" + Uri.ToString + "'.")

    End Function

    ''' <summary>Creates a YouTubeID from a id string.</summary>
    Public Shared Function FromIDString(Str As String) As YouTubeID
        Return New YouTubeID(Str)
    End Function

    Public Shared Function FromIDString(Str As String, Type As IDType) As YouTubeID
        Return New YouTubeID(Str, Type)
    End Function

#End Region
#Region "Functions"

    ''' <summary>Specifies id types.</summary>
    Public Enum IDType
        ''' <summary>Specifies that the type of the id could not be determined.</summary>
        Unknown = 0
        ''' <summary>Specifies that the id represents a video.</summary>
        Video = 1
        ''' <summary>Specifies that the id represents a playlist.</summary>
        Playlist = 2
        ''' <summary>Specifies that the id represents a channel.</summary>
        Channel = 3
    End Enum

    Private ID As String

    Private _Type As IDType
    ''' <summary>Gets the type of this YouTubeID.</summary>
    Public ReadOnly Property Type As IDType
        Get
            Return _Type
        End Get
    End Property

    ''' <summary>Checks if the id is valid or not.</summary>
    Public ReadOnly Property Valid As Boolean
        Get
            Return Not (Type = IDType.Unknown)
        End Get
    End Property

    ''' <summary>Checks if the id points to a existing video, playlist or channel.</summary>
    Public Function Exists() As Boolean

        'Connects to YouTube API and if page is not found then a video or playlist with that id exist.

        Dim link As String = ""

        If Type = IDType.Video Then
            link = Misc.Res.VideoAPI + ID
        ElseIf Type = IDType.Playlist Then
            link = Misc.Res.PlaylistAPI + ID
        ElseIf Type = IDType.Channel Then
            link = Misc.Res.ChannelAPI + ID
        End If

        Try
            System.Xml.Linq.XDocument.Load(link)
            Return True
        Catch e As System.Xml.XmlException
            'There was a problem parsing the xmldocument
            Return False
        Catch ex As System.Net.WebException
            'Page was not found
            Return False
        Catch ex1 As ArgumentException
            'ID is not valid and produces a uri not valid exception
            Return False
        End Try

    End Function

#End Region
#Region "Operators"

    Public Overrides Function ToString() As String
        Return ID
    End Function

    Public Shared Operator &(ByVal ID As YouTubeID, ByVal Str As String) As String
        Return New String(ID.ToString + Str)
    End Operator

    Public Shared Operator &(ByVal Str As String, ByVal ID As YouTubeID) As String
        Return New String(Str + ID.ToString)
    End Operator

    Public Shared Operator +(ByVal ID As YouTubeID, ByVal Str As String) As String
        Return New String(ID.ToString + Str)
    End Operator

    Public Shared Operator +(ByVal Str As String, ByVal ID As YouTubeID) As String
        Return New String(Str + ID.ToString)
    End Operator

    Public Shared Operator =(ByVal ID1 As YouTubeID, ByVal ID2 As YouTubeID) As Boolean
        Return (ID1.ToString = ID2.ToString)
    End Operator

    Public Shared Operator <>(ByVal ID1 As YouTubeID, ByVal ID2 As YouTubeID) As Boolean
        Return Not (ID1 = ID2)
    End Operator

#End Region

End Class
