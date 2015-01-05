Imports System.Xml

''' <summary>Represents an video on YouTube.</summary>
Public Class YouTubeVideo

    Private Sub New(ID As YouTubeID, PublishDate As Date, LatestUpdate As Date, Category As String, Title As String, Description As String, Uploader As YouTubeChannel, Thumbnails() As Uri, Length As TimeSpan, Rating As Misc.YouTubeVideoRating, Stats As Misc.YouTubeVideoStats)
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
    Public Shared Function FromURL(URL As Uri) As YouTubeVideo
        Dim id As YouTubeID = YouTubeID.FromURL(URL)
        Return FromID(id)
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


        Dim xml As New XmlDocument
        xml.Load(Res.VideoAPI + ID.ToString)

        Try
            Return ParseAPIXmlDocument(xml("entry"), ID)
        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
        End Try


        Throw New Misc.YouTubeException("The ID '" + ID.ToString + "' was not valid or does not exist.")


    End Function

    Friend Shared Function ParseAPIXmlDocument(Xmlnode As XmlNode, ID As YouTubeID) As YouTubeVideo

        Try

            Dim publishdate As Date = Misc.Extensions.ParseDateString(Xmlnode("published").InnerText)
            Dim latestupdate As Date = Misc.Extensions.ParseDateString(Xmlnode("updated").InnerText)
            Dim category As String = CType(Xmlnode("category").NextSibling, XmlElement).GetAttribute("label")
            Dim title As String = Xmlnode("title").InnerText
            Dim description As String = Xmlnode("content").InnerText
            Dim uploader As YouTubeChannel = YouTubeChannel.FromURL(New Uri(Xmlnode("author")("uri").InnerText))
            Dim length As TimeSpan = TimeSpan.FromSeconds(Xmlnode("media:group")("yt:duration").GetAttribute("seconds"))
            Dim rating As New Misc.YouTubeVideoRating(Double.Parse(Xmlnode("gd:rating").GetAttribute("average"), Globalization.NumberStyles.Any), CInt(Xmlnode("gd:rating").GetAttribute("numRaters")))
            Dim videostats As New Misc.YouTubeVideoStats(CInt(Xmlnode("yt:statistics").GetAttribute("favoriteCount")), CInt(Xmlnode("yt:statistics").GetAttribute("viewCount")))

            Dim thumbnails As New List(Of Uri)

            For Each n As XmlElement In Xmlnode("media:group")
                If n.Name = "media:thumbnail" Then
                    thumbnails.Add(New Uri(n.GetAttribute("url")))
                End If
            Next

            Return New YouTubeVideo(ID, publishdate, latestupdate, category, title, description, uploader, thumbnails.ToArray, length, rating, videostats)

        Catch ex As XmlException
            Throw New Misc.YouTubeException("An error occured when parsing xml file.", ex)
        End Try

    End Function

    Public Overrides Function ToString() As String

    End Function

    Public Function GetURL(Optional Embed As Boolean = False, Optional Quality As VideoQuality = VideoQuality.Auto, Optional Autoplay As Boolean = False, Optional ) As Uri

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
        Normal = 0
        ''' <summary>Specifies that the player should never display the controls.</summary>
        NeverShow = 1
        ''' <summary>Specifes that the player should display them like normal but wait for a while longer.</summary>
        NormalButDelayed = 2
    End Enum

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

    Private _Thumbnails As Uri()
    ''' <summary>Gets a list of urls pointing to different versions of the thumbnail of this video.</summary>
    Public ReadOnly Property Thumbnails As Uri()
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

End Class
