Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.Net

''' <summary>Represents a channel on YouTube.</summary>
Public Class YouTubeChannel
    Implements IDisposable

#Region "Constructors"

    Private Sub New(ID As YouTubeID, CreationDate As Date, LatestUpdate As Date, Name As String, Description As String, GooglePlusUserID As String, Location As String, Stats As Misc.ChannelStats, Thumbnail As Misc.Thumbnail)
        Me._ID = ID
        Me._CreationDate = CreationDate
        Me._LatestUpdate = LatestUpdate
        Me._Name = Name
        Me._Description = Description
        Me._GooglePlusUserID = GooglePlusUserID
        Me._Location = Location
        Me._Stats = Stats
        Me._Thumbnail = Thumbnail
    End Sub

    Public Shared Function FromName(Name As String) As YouTubeChannel
        Return FromID(YouTubeID.FromIDString(Name))
    End Function

    ''' <summary>Creates a YouTube channel from an YouTube channel url.</summary>
    Public Shared Function FromUri(Uri As Uri) As YouTubeChannel
        Return FromID(YouTubeID.FromUri(Uri))
    End Function

    ''' <summary>Creates a YouTube channel from an id.</summary>
    Public Shared Function FromID(ID As YouTubeID) As YouTubeChannel


        If Not ID.Valid Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' is not valid.")
        End If

        If Not ID.Type = YouTubeID.IDType.Channel Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent a channel.")
        End If

        If Not ID.Exists Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent an existing channel.")
        End If


        If Cache.VideoExists(ID) Then
            Return Cache.GetChannel(ID)
        Else

            Dim xml As New XmlDocument
            xml.Load(Misc.Res.ChannelAPI + ID.ToString)

            Try
                Return ParseAPIXml(xml("entry"), ID)
            Catch ex As XmlException
                Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
            End Try

        End If


    End Function

    Friend Shared Function ParseAPIXml(XmlNode As XmlNode, ID As YouTubeID) As YouTubeChannel

        Try

            Dim created As Date = Date.Parse(XmlNode("published").InnerText)
            Dim latestupdate As Date = Date.Parse((XmlNode("updated").InnerText))
            Dim name As String = XmlNode("title").InnerText
            Dim description As String = XmlNode("content").InnerText

            Dim googleplususerid As String = ""
            If XmlNode("yt:googlePlusUserId") IsNot Nothing Then
                googleplususerid = XmlNode("yt:googlePlusUserId").InnerText
            End If

            Dim location As String = ""
            If XmlNode("yt:location") IsNot Nothing Then
                location = XmlNode("yt:location").InnerText
            End If

            Dim stats As Misc.ChannelStats = Nothing
            If XmlNode("yt:statistics") IsNot Nothing Then
                stats = New Misc.ChannelStats(XmlNode("yt:statistics").GetAttribute("subscriberCount"), XmlNode("yt:statistics").GetAttribute("totalUploadViews"))
            End If

            Dim thumbnail As Misc.Thumbnail = Nothing
            If XmlNode("media:thumbnail") IsNot Nothing Then
                thumbnail = Misc.Thumbnail.ParseAPINode(XmlNode("media:thumbnail"))
            End If

            Return New YouTubeChannel(ID, created, latestupdate, name, description, googleplususerid, location, stats, thumbnail)

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
        End Try

    End Function

#End Region
#Region "Functions"

    ''' <summary>Gets the id from an username.</summary>
    Public Shared Function GetIDFromUsername(Name As String) As YouTubeID

        Dim link As String = Misc.Res.ChannelAPI + Name

        Try

            Dim xml As New XmlDocument
            xml.Load(link)
            MsgBox(xml("entry")("id").InnerText)
            Return YouTubeID.FromUri(New Uri(xml("entry")("id").InnerText))

        Catch e As System.Xml.XmlException
            'There was a problem parsing the xmldocument
            Throw New Misc.YouTubeException("An error occured when parsing the xml document.", e)
        Catch ex As System.Net.WebException
            'Page was not found
            Throw New Misc.YouTubeException("The specified channel name does not exist.", ex)
        End Try

    End Function

    ''' <summary>Refreshes the information of this channel.</summary>
    Public Sub Refresh()
        With YouTubeChannel.FromID(Me.ID)
            _CreationDate = .CreationDate
            _LatestUpdate = .LatestUpdate
            _Name = .Name
            _Description = .Description
            _GooglePlusUserID = .GooglePlusUserID
            _Location = .Location
            _Stats = .Stats
            _Thumbnail = .Thumbnail
        End With
    End Sub

    Public Function GetAllVideos() As YouTubeVideo()

        Dim vids As New List(Of YouTubeVideo)
        Dim returncount As Integer = -1
        Dim index As Integer = 1

        Dim terminate As Boolean = False

        Do Until returncount = 0 Or terminate

            Try
                Dim v() As YouTubeVideo = GetVideos(index, 50)
                returncount = v.Count
                MsgBox(returncount)
                vids.AddRange(v)
                index += 50
            Catch ex As WebException
                terminate = True
            End Try
        Loop

        Return vids.ToArray

    End Function

    ''' <summary>Gets an array of videos that has been uploaded on this channel.</summary>
    ''' <param name="MaxResults">Specifies the max amount of videos that should be returned. Maximum is 50.</param>
    Public Function GetVideos(Optional StartIndex As Integer = 1, Optional MaxResults As Integer = 25) As YouTubeVideo()

        If StartIndex < 1 Then
            StartIndex = 1
        End If

        If MaxResults < 1 Then
            Return Nothing
        ElseIf MaxResults > 50 Then
            MaxResults = 50
        End If

        Try

            Dim xml As New XmlDocument

            xml.Load(Misc.Res.ChannelAPI + ID + "/uploads?start-index=" + StartIndex.ToString + "&max-results=" + MaxResults.ToString)

            Dim l As New List(Of YouTubeVideo)
            For Each n As XmlElement In xml("feed")
                If n.Name = "entry" Then
                    Dim id As YouTubeID = YouTubeID.FromIDString(n("id").InnerText.Split("/").Last, YouTubeID.IDType.Video)
                    l.Add(YouTubeVideo.FromID(id, Me))
                End If
            Next

            Return l.ToArray

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured while parsing xml document", ex)
        End Try

    End Function

    ''' <summary>Get all playlists created by this channel. Note that all videos will be instantiated as well.</summary>
    Public Function GetPlaylists(Optional StartIndex As Integer = 1, Optional MaxResults As Integer = 25) As YouTubePlaylist()

        Try

            Dim xml As New XmlDocument
            xml.Load(Misc.Res.ChannelAPI + ID + "/playlists?start-index=" + StartIndex.ToString + "&max-results=" + MaxResults.ToString)

            Dim l As New List(Of YouTubePlaylist)
            For Each n As XmlElement In xml("feed")
                If n.Name = "entry" Then
                    l.Add(YouTubePlaylist.ParseAPIXml(n, YouTubeID.FromIDString(n("id").InnerText.Split("/").Last)))
                End If
            Next

            Return l.ToArray

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured while parsing xml document", ex)
        End Try

    End Function

    ''' <summary>Gets channels that this channel is subsribed to.</summary>
    Public Function GetSubscriptions(Optional StartIndex As Integer = 1, Optional MaxResults As Integer = 25) As YouTubeChannel()

        Try

            Dim xml As New XmlDocument
            xml.Load(Misc.Res.ChannelAPI + ID + "/subscriptions?start-index=" + StartIndex.ToString + "&max-results=" + MaxResults.ToString)

            Dim l As New List(Of YouTubeChannel)
            For Each n As XmlElement In xml("feed")
                If n.Name = "entry" Then
                    l.Add(YouTubeChannel.FromID(YouTubeID.FromUri(New Uri(n("link").GetAttribute("href")))))
                End If
            Next

            Return l.ToArray

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured while parsing xml document", ex)
        End Try

    End Function

    ''' <summary>Get all videos that would be played when an unsubscribed user visits this channel.</summary>
    Public Function GetNewSubscriptionVideos() As YouTubeVideo()

        Try

            Dim xml As New XmlDocument
            xml.Load(Misc.Res.ChannelAPI + ID + "/newsubscriptionvideos")


            Dim l As New List(Of YouTubeVideo)
            For Each n As XmlNode In xml("feed")
                If n.Name = "entry" Then
                    l.Add(YouTubeVideo.ParseAPIXml(n, YouTubeID.FromIDString(n("id").InnerText.Split("/").Last, YouTubeID.IDType.Video)))
                End If
            Next

            Return l.ToArray

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured while parsing xml document", ex)
        End Try

    End Function

    ''' <summary>Returns a uri pointing to the channel on YouTube.</summary>
    Public Function GetUri() As Uri
        Return New Uri("https://www.youtube.com/channel/" + Me.ID)
    End Function

    ''' <summary>Returns a uri pointing to the api for the channel on YouTube.</summary>
    Public Function GetAPIUri() As Uri
        Return New Uri(Misc.Res.ChannelAPI + Me.ID)
    End Function

#End Region
#Region "Properties"

    Private _ID As YouTubeID
    ''' <summary>Gets the id of this channel.</summary>
    Public ReadOnly Property ID As YouTubeID
        Get
            Return _ID
        End Get
    End Property

    Private _CreationDate As Date
    ''' <summary>Gets the date this channel was created.</summary>
    Public ReadOnly Property CreationDate As Date
        Get
            Return _CreationDate
        End Get
    End Property

    Private _LatestUpdate As Date
    ''' <summary>Gets the date this channel was last updated.</summary>
    Public ReadOnly Property LatestUpdate As Date
        Get
            Return _LatestUpdate
        End Get
    End Property

    Private _Description As String
    ''' <summary>Gets the description of this channel.</summary>
    Public ReadOnly Property Description As String
        Get
            Return _Description
        End Get
    End Property

    Private _Name As String
    ''' <summary>Gets the name of this channel.</summary>
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property

    Private _GooglePlusUserID As String
    ''' <summary>Gets the channel user id on google+.</summary>
    Public ReadOnly Property GooglePlusUserID As String
        Get
            Return _GooglePlusUserID
        End Get
    End Property

    Private _Location As String
    ''' <summary>Gets the location of this channel.</summary>
    Public ReadOnly Property Location As String
        Get
            Return _Location
        End Get
    End Property

    Private _Stats As Misc.ChannelStats
    ''' <summary>Gets the stats of this channel.</summary>
    Public ReadOnly Property Stats As Misc.ChannelStats
        Get
            Return _Stats
        End Get
    End Property

    Private _Thumbnail As Misc.Thumbnail
    ''' <summary>Gets an uri pointing to a bitmap that is the thumbnail of this channel.</summary>
    Public ReadOnly Property Thumbnail As Misc.Thumbnail
        Get
            Return _Thumbnail
        End Get
    End Property

#End Region
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Cache.RemoveChannel(Me)
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
