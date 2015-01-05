Imports System.Xml

Public Class YouTubePlaylist
    Implements IDisposable

#Region "Constructors"

    Private Sub New(ID As YouTubeID, Channel As YouTubeChannel, LatestUpdate As Date, Title As String, Description As String, Thumbnails As Misc.Thumbnail(), Videos As List(Of YouTubeVideo))
        Me._ID = ID
        Me._Channel = Channel
        Me._LatestUpdate = LatestUpdate
        Me._Title = Title
        Me._Description = Description
        Me._Thumbnails = Thumbnails
        Me._Videos = Videos
    End Sub

    Public Shared Function FromUri(Uri As Uri) As YouTubePlaylist
        Dim id As YouTubeID = YouTubeID.FromUri(Uri)
        Return FromID(id)
    End Function

    Public Shared Function FromID(ID As YouTubeID) As YouTubePlaylist


        If Not ID.Valid Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' is not valid.")
        End If

        If Not ID.Type = YouTubeID.IDType.Playlist Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent a playlist.")
        End If

        If Not ID.Exists Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent an existing playlist.")
        End If


        If Cache.VideoExists(ID) Then
            Return Cache.GetPlaylist(ID)
        Else

            Dim xml As New XmlDocument
            xml.Load(Misc.Res.PlaylistAPI + ID.ToString)

            Try
                Return ParseAPIXml(xml("feed"), ID)
            Catch ex As XmlException
                Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
            End Try

        End If


    End Function

    Friend Shared Function ParseAPIXml(Xmlnode As XmlNode, ID As YouTubeID) As YouTubePlaylist

        Dim latestupdate As Date = Date.Parse((Xmlnode("updated").InnerText))
        Dim title As String = Xmlnode("title").InnerText

        Dim description As String = ""
        If Xmlnode("subtitle") IsNot Nothing Then
            description = Xmlnode("subtitle").InnerText
        ElseIf Xmlnode("content") IsNot Nothing Then
            description = Xmlnode("content").InnerText
        End If

        Dim thumbnails As New List(Of Misc.Thumbnail)
        For Each n As XmlElement In Xmlnode("media:group")
            If n.Name = "media:thumbnail" Then
                thumbnails.Add(Misc.Thumbnail.ParseAPINode(n))
            End If
        Next

        Dim ch As YouTubeChannel = YouTubeChannel.FromUri(New Uri(Xmlnode("author")("uri").InnerText))

        Dim v As New List(Of YouTubeVideo)
        For Each n As XmlNode In Xmlnode
            If n.Name = "entry" Then

                Dim vid As YouTubeID = YouTubeID.FromUri(New Uri(n("link").GetAttribute("href")))

                If vid.Valid Then
                    If Cache.VideoExists(vid) Then
                        v.Add(Cache.GetVideo(vid))
                    Else
                        v.Add(YouTubeVideo.ParseAPIXml(n, vid, ch))
                    End If
                End If
            End If
        Next

        Return New YouTubePlaylist(ID, ch, latestupdate, title, description, thumbnails.ToArray, v)

    End Function

#End Region
#Region "Functions"

    ''' <summary>Refreshes the information of this playlist.</summary>
    Public Sub Refresh()
        With YouTubePlaylist.FromID(Me.ID)
            _LatestUpdate = .LatestUpdate
            _Title = .Title
            _Description = .Description
            _Thumbnails = .Thumbnails
            _Channel = .Channel
            _Videos = .Videos
        End With
    End Sub

    ''' <summary>Returns a uri pointing to the playlist on YouTube.</summary>
    Public Function GetUri(Playlist As YouTubePlaylist) As Uri
        Return New Uri("https://www.youtube.com/playlist?list=" + Playlist.ID)
    End Function

    ''' <summary>Returns a uri pointing to the api for the playlist on YouTube.</summary>
    Public Function GetUri(Channel As YouTubeChannel) As Uri
        Return New Uri("https://www.youtube.com/channel/" + Channel.ID)
    End Function

#End Region
#Region "Properties"

    Private _ID As YouTubeID
    Public ReadOnly Property ID As YouTubeID
        Get
            Return _ID
        End Get
    End Property

    Private _Channel As YouTubeChannel
    Public ReadOnly Property Channel As YouTubeChannel
        Get
            Return _Channel
        End Get
    End Property

    Private _LatestUpdate As Date
    Public ReadOnly Property LatestUpdate As Date
        Get
            Return _LatestUpdate
        End Get
    End Property

    Private _Title As String
    Public ReadOnly Property Title As String
        Get
            Return _Title
        End Get
    End Property

    Private _Description As String
    Public ReadOnly Property Description As String
        Get
            Return _Description
        End Get
    End Property

    Private _Thumbnails As Misc.Thumbnail()
    Public ReadOnly Property Thumbnails As Misc.Thumbnail()
        Get
            Return _Thumbnails
        End Get
    End Property

    Private _Videos As List(Of YouTubeVideo)
    Public ReadOnly Property Videos As IReadOnlyCollection(Of YouTubeVideo)
        Get
            Return _Videos.AsReadOnly
        End Get
    End Property

#End Region
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Cache.RemovePlaylist(Me)
            End If
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
