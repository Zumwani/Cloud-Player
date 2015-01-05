Imports System.Xml

''' <summary>Represents an video on YouTube.</summary>
Public Class YouTubeVideo
    Implements IDisposable

#Region "Constructors"

    Private Sub New(ID As YouTubeID, PublishDate As Date, LatestUpdate As Date, Category As String, Title As String, Description As String, Uploader As YouTubeChannel, Thumbnails As Misc.Thumbnail(), Length As TimeSpan, Rating As Misc.YouTubeVideoRating, Stats As Misc.YouTubeVideoStats)
        Me._ID = ID
        Me._PublishDate = PublishDate
        Me._LatestUpdate = LatestUpdate
        Me._Category = Category
        Me._Title = Title
        Me._Description = Description
        Me._Uploader = Uploader
        Me._Thumbnails = Thumbnails
        Me._Length = Length
        Me._Rating = Rating
        Me._VideoStats = Stats
    End Sub

    ''' <summary>Creates a YouTube video from an YouTube video url.</summary>
    Public Shared Function FromUri(Uri As Uri) As YouTubeVideo
        Dim id As YouTubeID = YouTubeID.FromUri(Uri)
        Return FromID(id)
    End Function

    Friend Shared Function FromID(ID As YouTubeID, Channel As YouTubeChannel) As YouTubeVideo

        If Not ID.Valid Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' is not valid.")
        End If

        If Not ID.Type = YouTubeID.IDType.Video Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent a video.")
        End If

        If Not ID.Exists Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent an existing video.")
        End If

        If Cache.VideoExists(ID) Then
            Return Cache.GetVideo(ID)
        Else

            Dim xml As New XmlDocument
            xml.Load(Misc.Res.VideoAPI + ID.ToString)

            Try
                Return ParseAPIXml(xml("entry"), ID, Channel)
            Catch ex As XmlException
                Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
            End Try

        End If

    End Function

    ''' <summary>Creates a YouTube video from an id.</summary>
    Public Shared Function FromID(ID As YouTubeID) As YouTubeVideo

        If Not ID.Valid Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' is not valid.")
        End If

        If Not ID.Type = YouTubeID.IDType.Video Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent a video.")
        End If

        If Not ID.Exists Then
            Throw New Misc.YouTubeException("The id '" + ID.ToString + "' does not represent an existing video.")
        End If

        If Cache.VideoExists(ID) Then
            Return Cache.GetVideo(ID)
        Else

            Dim xml As New XmlDocument
            xml.Load(Misc.Res.VideoAPI + ID.ToString)

            Try
                Return ParseAPIXml(xml("entry"), ID)
            Catch ex As XmlException
                Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
            End Try

        End If

    End Function

    Friend Shared Function ParseAPIXml(Xmlnode As XmlNode, ID As YouTubeID, Optional Channel As YouTubeChannel = Nothing) As YouTubeVideo

        Try

            Dim publishdate As Date = Date.Parse((Xmlnode("published").InnerText))
            Dim latestupdate As Date = Date.Parse((Xmlnode("updated").InnerText))
            Dim category As String = CType(Xmlnode("category").NextSibling, XmlElement).GetAttribute("label")
            Dim title As String = Xmlnode("title").InnerText
            Dim description As String = Xmlnode("content").InnerText

            If Channel Is Nothing Then
                Channel = YouTubeChannel.FromUri(New Uri(Xmlnode("author")("uri").InnerText))
            End If

            Dim length As TimeSpan = TimeSpan.FromSeconds(Xmlnode("media:group")("yt:duration").GetAttribute("seconds"))
            Dim rating As New Misc.YouTubeVideoRating(Double.Parse(Xmlnode("gd:rating").GetAttribute("average"), Globalization.NumberStyles.Any), CInt(Xmlnode("gd:rating").GetAttribute("numRaters")))
            Dim videostats As New Misc.YouTubeVideoStats(CInt(Xmlnode("yt:statistics").GetAttribute("favoriteCount")), CInt(Xmlnode("yt:statistics").GetAttribute("viewCount")))

            Dim thumbnails As New List(Of Misc.Thumbnail)

            For Each n As XmlElement In Xmlnode("media:group")
                If n.Name = "media:thumbnail" Then
                    thumbnails.Add(Misc.Thumbnail.ParseAPINode(n))
                End If
            Next

            Return New YouTubeVideo(ID, publishdate, latestupdate, category, title, description, Channel, thumbnails.ToArray, length, rating, videostats)

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
        End Try

    End Function

#End Region

    Public Overrides Function ToString() As String
        Return GetUri().ToString
    End Function

    ''' <summary>Refreshes the information of this video.</summary>
    Public Sub Refresh()
        With YouTubeVideo.FromID(Me.ID)
            _PublishDate = .PublishDate
            _LatestUpdate = .LatestUpdate
            _Category = .Category
            _Title = .Title
            _Description = .Description
            _Uploader = .Uploader
            _Length = .Length
            _Rating = .Rating
            _VideoStats = .VideoStats
            _Thumbnails = .Thumbnails
        End With
    End Sub

    Public Shared Function Search(SearchString As String, Optional MaxResults As Integer = 25, Optional StartIndex As Integer = 1, Optional Category As Misc.YouTubeCategory = Nothing) As YouTubeVideo()

        If MaxResults > 50 Then
            MaxResults = 50
        ElseIf MaxResults < 1 Then
            Return {}
        End If

        If StartIndex < 0 Then
            StartIndex = 0
        End If

        Try

            Dim xml As New XmlDocument
            If Category IsNot Nothing Then
                xml.Load(Misc.Res.SearchAPI + SearchString + "&maxresults=" + MaxResults.ToString + "&startindex=" + StartIndex.ToString + "&category=" + Category.Name)
            Else
                xml.Load(Misc.Res.SearchAPI + SearchString + "&maxresults=" + MaxResults.ToString + "&startindex=" + StartIndex.ToString)
            End If

            Dim l As New List(Of YouTubeVideo)
            For Each n As XmlElement In xml("feed")
                If n.Name = "entry" Then
                    Dim id As YouTubeID = YouTubeID.FromIDString(n("id").InnerText.Split("/").Last, YouTubeID.IDType.Video)
                    l.Add(YouTubeVideo.FromID(id))
                End If
            Next

            Return l.ToArray

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured while parsing xml document", ex)
        End Try

    End Function

#Region "Properties"

    Private _ID As YouTubeID
    ''' <summary>Gets the id of this video.</summary>
    Public ReadOnly Property ID As YouTubeID
        Get
            Return _ID
        End Get
    End Property

    Private _PublishDate As Date
    ''' <summary>Gets the date that this video was published.</summary>
    Public ReadOnly Property PublishDate As Date
        Get
            Return _PublishDate
        End Get
    End Property

    Private _LatestUpdate As Date
    ''' <summary>Gets the date when this video was last updated.</summary>
    Public ReadOnly Property LatestUpdate As Date
        Get
            Return _LatestUpdate
        End Get
    End Property

    Private _Category As String
    ''' <summary>Gets the category of this video.</summary>
    Public ReadOnly Property Category As String
        Get
            Return _Category
        End Get
    End Property

    Private _Title As String
    ''' <summary>Gets the title of this video.</summary>
    Public ReadOnly Property Title As String
        Get
            Return _Title
        End Get
    End Property

    Private _Description As String
    ''' <summary>Gets the description of this video.</summary>
    Public ReadOnly Property Description As String
        Get
            Return _Description
        End Get
    End Property

    Private _Uploader As YouTubeChannel
    ''' <summary>Gets the channel that this video belongs to.</summary>
    Public ReadOnly Property Uploader As YouTubeChannel
        Get
            Return _Uploader
        End Get
    End Property

    Private _Thumbnails As Misc.Thumbnail()
    ''' <summary>Gets a list of urls pointing to different versions of the thumbnail of this video.</summary>
    Public ReadOnly Property Thumbnails As Misc.Thumbnail()
        Get
            Return _Thumbnails
        End Get
    End Property

    Private _Length As TimeSpan
    ''' <summary>Gets the length of this video.</summary>
    Public ReadOnly Property Length As TimeSpan
        Get
            Return _Length
        End Get
    End Property

    Private _Rating As Misc.YouTubeVideoRating
    ''' <summary>Gets the rating of this video.</summary>
    Public ReadOnly Property Rating As Misc.YouTubeVideoRating
        Get
            Return _Rating
        End Get
    End Property

    Private _VideoStats As Misc.YouTubeVideoStats
    ''' <summary>Gets the stats for this video.</summary>
    Public ReadOnly Property VideoStats As Misc.YouTubeVideoStats
        Get
            Return _VideoStats
        End Get
    End Property

#End Region
#Region "GetUri"

    ''' <summary>Returns a uri pointing to the video on YouTube.</summary>
    Public Function GetUri(Optional Embed As Boolean = False, Optional Quality As VideoQuality = VideoQuality.Auto, Optional Autoplay As Boolean = False, _
                       Optional ControlVisibility As ControlVisibility = ControlVisibility.Normal, Optional DisableKeyboard As Boolean = False, Optional StartTime As Integer = -1, _
                       Optional StopTime As Integer = -1, Optional ForceCaptions As Boolean = False, Optional ForceWhitePlayer As Boolean = False, Optional ForceWhiteProgressbar As Boolean = False, _
                       Optional HideAnnotations As Boolean = False, Optional HideBranding As Boolean = False, Optional HideRelatedVideos As Boolean = False, Optional HideTitlebar As Boolean = False, _
                       Optional LoopVideo As Boolean = False, Optional UIVisiblility As UIVisibility = UIVisibility.Normal) As Uri

        Dim link As String = ""

        If Embed Then
            link = Misc.Res.Embed
        Else
            link = "https://www.youtube.com/watch?v="
        End If

        link += Me.ID + "?"

        Select Case Quality
            Case Is = VideoQuality._240p
                link += Misc.Res._240pString + "&"
            Case Is = VideoQuality._360p
                link += Misc.Res._360pString + "&"
            Case Is = VideoQuality._480p
                link += Misc.Res._480pString + "&"
            Case Is = VideoQuality._720p
                link += Misc.Res._720pString + "&"
            Case Is = VideoQuality._1080p
                link += Misc.Res._1080pString + "&"
        End Select

        If Autoplay Then
            link += Misc.Res.AutoplayString + "&"
        End If

        Select Case ControlVisibility
            Case Is = ControlVisibility.NeverShow
                link += Misc.Res.ControlsForceHideString + "&"
            Case Is = ControlVisibility.NormalButDelayed
                link += Misc.Res.ControlsDelayHideString + "&"
        End Select

        If DisableKeyboard Then
            link += Misc.Res.DisableKeyboardString + "&"
        End If

        If Not StartTime = -1 Then
            link += Misc.Res.StartString + StartTime.ToString + "&"
        End If

        If Not StopTime = -1 Then
            link += Misc.Res.EndString + StopTime.ToString + "&"
        End If

        If ForceCaptions Then
            link += Misc.Res.ForceCaptionsString + "&"
        End If

        If ForceWhitePlayer Then
            link += Misc.Res.ForceWhitePlayerString + "&"
        End If

        If ForceWhiteProgressbar Then
            link += Misc.Res.ForceWhiteProgressbar + "&"
        End If

        If HideAnnotations Then
            link += Misc.Res.HideAnnotationsString + "&"
        End If

        If HideBranding Then
            link += Misc.Res.HideBrandingString + "&"
        End If

        If HideRelatedVideos Then
            link += Misc.Res.HideRelatedVideosString + "&"
        End If

        If HideTitlebar Then
            link += Misc.Res.ForceCaptionsString + "&"
        End If

        If LoopVideo Then
            link += Misc.Res.LoopVideoString + Me.ID + "&"
        End If

        Select Case UIVisiblility
            Case Is = UIVisibility.AlwaysShow
                link += Misc.Res.UIForceShowString + "&"
            Case Is = UIVisibility.HideOnlyProgressbar
                link += Misc.Res.UIProgressbarHideString + "&"
        End Select

        link = link.Remove(link.Length - 1, 1)

        Return New Uri(link)

    End Function

    Public Enum VideoQuality
        Auto = 0
        _240p = 1
        _360p = 2
        _480p = 3
        _720p = 4
        _1080p = 5
    End Enum

    Public Enum ControlVisibility
        ''' <summary>Specifies that the player controls should behave normally, shown for a few seconds before hiding.</summary>
        Normal = 1
        ''' <summary>Specifies that the player should never display the controls.</summary>
        NeverShow = 0
        ''' <summary>Specifes that the player should display them like normal but wait for a while longer.</summary>
        NormalButDelayed = 2
    End Enum

    Public Enum UIVisibility
        Normal = 1
        AlwaysShow = 0
        HideOnlyProgressbar = 2
    End Enum

    ''' <summary>Returns a uri pointing to the api for the video on YouTube.</summary>
    Public Function GetAPIUri() As Uri
        Return New Uri(Misc.Res.VideoAPI + Me.ID)
    End Function

#End Region
#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Cache.RemoveVideo(Me)
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
