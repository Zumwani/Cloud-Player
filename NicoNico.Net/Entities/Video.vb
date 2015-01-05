Imports System.Xml
Imports System.Net

''' <summary>Represents a video on Nico Nico.</summary>
Public Class Video
    Implements IDisposable

#Region "Contructors"

    Private Sub New(ID As ID, Title As String, Description As String, Thumbnail As Uri, UploadDate As Date, Length As TimeSpan, LowQualitySize As Integer, HighQualitySize As Integer, Stats As Misc.NicoNicoVideoStats, Embeddable As Boolean, Tags As String(), UploaderName As String, UploaderThumbnail As Uri)
        Me._ID = ID
        Me._Title = Title
        Me._Description = Description
        Me._Thumbnail = Thumbnail
        Me._UploadDate = UploadDate
        Me._Length = Length
        Me._LowQualitySize = LowQualitySize
        Me._HighQualitySize = HighQualitySize
        Me._Stats = Stats
        Me._Embeddable = Embeddable
        Me._Tags = Tags
        Me._UploaderName = UploaderName
        Me._UploaderThumbnail = UploaderThumbnail
    End Sub

    ''' <summary>Creates a video from the specified uri.</summary>
    Public Shared Function FromUri(Uri As Uri) As Video
        Dim id As ID = ID.FromUri(Uri)
        Return FromID(id)
    End Function

    ''' <summary>Creates a video from the specifed ID.</summary>
    Public Shared Function FromID(ID As ID) As Video

        If Not ID.Exists Then
            Throw New Misc.NicoNicoException("The id '" + ID.ToString + "' does not represent an existing video.")
        End If

        If Cache.VideoExists(ID) Then
            Return Cache.GetVideo(ID)
        Else

            Dim xml As New XmlDocument
            xml.Load(String.Format(Misc.Res.VideoAPI, ID.ToString))

            Try
                Return ParseAPIXml(xml("nicovideo_thumb_response")("thumb"), ID)
            Catch ex As XmlException
                Throw New Misc.NicoNicoException("An error occured when parsing xml file.", ex)
            End Try

        End If

    End Function

    Public Shared Function ParseAPIXml(Xmlnode As XmlNode, ID As ID) As Video

        Try

            If Xmlnode Is Nothing Then
                Return Nothing
            End If

            Dim title As String = Xmlnode("title").InnerText
            Dim description As String = Xmlnode("description").InnerText
            Dim thumbnail As Uri = New Uri(Xmlnode("thumbnail_url").InnerText)
            Dim uploaddate As Date = Date.Parse(Xmlnode("first_retrieve").InnerText)
            Dim length As TimeSpan = TimeSpan.Parse(Xmlnode("length").InnerText)
            Dim lowsize As Integer = CInt(Xmlnode("size_low").InnerText)
            Dim highsize As Integer = CInt(Xmlnode("size_high").InnerText)
            Dim stats As New Misc.NicoNicoVideoStats(CInt(Xmlnode("view_counter").InnerText), CInt(Xmlnode("comment_num").InnerText), CInt(Xmlnode("mylist_counter").InnerText))
            Dim embeddable As Boolean = (Xmlnode("embeddable").InnerText = 1)

            Dim tags As New List(Of String)
            For Each n As XmlNode In Xmlnode("tags")
                tags.Add(n.InnerText)
            Next

            Dim uploadername As String = Xmlnode("user_nickname").InnerText
            Dim uploaderthumbnail As New Uri(Xmlnode("user_icon_url").InnerText)

            Return New Video(ID, title, description, thumbnail, uploaddate, length, lowsize, highsize, stats, embeddable, tags.ToArray, uploadername, uploaderthumbnail)

        Catch ex As XmlException
            Throw New Misc.NicoNicoException("An error occured when parsing xml file.", ex)
        End Try

    End Function

#End Region
#Region "Properties"

    Private _ID As ID
    ''' <summary>Gets the ID of this video.</summary>
    Public ReadOnly Property ID As ID
        Get
            Return _ID
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

    Private _Thumbnail As Uri
    ''' <summary>Gets the uri pointing to the thumbnail of this video.</summary>
    Public ReadOnly Property Thumbnail As Uri
        Get
            Return _Thumbnail
        End Get
    End Property

    Private _UploadDate As Date
    ''' <summary>Gets the date that this video was uploaded.</summary>
    Public ReadOnly Property UploadDate As Date
        Get
            Return _UploadDate
        End Get
    End Property

    Private _Length As TimeSpan
    ''' <summary>Gets a timespan that represents the length of this video.</summary>
    Public ReadOnly Property Length As TimeSpan
        Get
            Return _Length
        End Get
    End Property

    Private _HighQualitySize As Integer
    ''' <summary>Gets the high quality version size in bytes of this video.</summary>
    Public ReadOnly Property HighQualitySize As Integer
        Get
            Return _HighQualitySize
        End Get
    End Property

    Private _LowQualitySize As Integer
    ''' <summary>Gets the low quality version size in bytes of this video.</summary>
    Public ReadOnly Property LowQualitySize As Integer
        Get
            Return _LowQualitySize
        End Get
    End Property

    Private _Stats As Misc.NicoNicoVideoStats
    ''' <summary>Gets the stats for this video.</summary>
    Public ReadOnly Property Stats As Misc.NicoNicoVideoStats
        Get
            Return _Stats
        End Get
    End Property

    Private _Embeddable As Boolean
    ''' <summary>Gets whatever this video is flagged as embeddable.</summary>
    Public ReadOnly Property Embeddable As Boolean
        Get
            Return _Embeddable
        End Get
    End Property

    Private _Tags As String()
    ''' <summary>Gets the tags of this video.</summary>
    Public ReadOnly Property Tags As String()
        Get
            Return _Tags
        End Get
    End Property

    Private _UploaderName As String
    ''' <summary>Gets the name of the uploader of this video.</summary>
    Public ReadOnly Property UploaderName As String
        Get
            Return _UploadDate
        End Get
    End Property

    Private _UploaderThumbnail As Uri
    ''' <summary>Gets the uri pointing to the thumbnail the user that uploaded this video.</summary>
    Public ReadOnly Property UploaderThumbnail As Uri
        Get
            Return _UploaderThumbnail
        End Get
    End Property

    Public ReadOnly Property EmbedLink As Uri
        Get

        End Get
    End Property

#End Region
#Region "Extra functions"

    ''' <summary>Performs a search Nico Nico, returning the returned videos.</summary>
    Public Shared Function Search(SearchString As String) As Video()

        Dim link As New Uri(String.Format(Misc.Res.SearchAPI, SearchString))

        Using client As New WebClient

            Dim result As String = client.DownloadString(link)
            MsgBox(result)
        End Using

        'http://ext.nicovideo.jp/api/search/search/%E8%8A%B1%E3%81%9F%E3%82%93?mode=watch&sort=v&order=d&page=1
        Return Nothing
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
