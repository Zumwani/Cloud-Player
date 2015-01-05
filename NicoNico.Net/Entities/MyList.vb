Imports System.Xml

''' <summary>Represents a mylist on Nico Nico.</summary>
Public Class MyList
    Implements IDisposable

    Private Sub New(ID As ID, Title As String, Description As String, PublishDate As Date, LatestUpdate As Date, Creator As String, Videos As ID())
        Me._ID = ID
        Me._Title = Title
        Me._Description = Description
        Me._PublishDate = PublishDate
        Me._LatestUpdate = LatestUpdate
        Me._Creator = Creator
        Me._Videos = Videos
    End Sub

    ''' <summary>Creates a NicoNicoMyList from the specified uri.</summary>
    Public Shared Function FromUri(Uri As Uri) As MyList
        Dim id As ID = ID.FromUri(Uri)
        Return FromID(id)
    End Function

    ''' <summary>Creates a NicoNicoMyList from the specified ID.</summary>
    Public Shared Function FromID(ID As ID) As MyList

        'If Not ID.Exists Then
        '    Throw New Misc.NicoNicoException("The id '" + ID.ToString + "' does not represent an existing mylist.")
        'End If

        If Cache.MyListExists(ID) Then
            Return Cache.GetMyList(ID)
        Else

            Dim xml As New XmlDocument
            xml.Load(GetAPIUri(ID).OriginalString)

            Try
                Return MyList.ParseAPIXml(xml("rss")("channel"), ID)
            Catch ex As XmlException
                Throw New Misc.NicoNicoException("An error occured when parsing xml file.", ex)
            End Try

        End If

    End Function

    Friend Shared Function ParseAPIXml(Xmlnode As XmlNode, ID As ID) As MyList

        Dim title As String = Xmlnode("title").InnerText
        Dim description As String = Xmlnode("description").InnerText
        Dim created As Date = Date.Parse(Xmlnode("pubDate").InnerText)
        Dim latestupdate As Date = Date.Parse(Xmlnode("lastBuildDate").InnerText)

        Dim creator As String = Xmlnode("dc:creator").InnerText

        Dim v As New List(Of ID)
        For Each n As XmlNode In Xmlnode
            If n.Name = "item" Then
                Dim vid As ID = ID.FromUri(New Uri(n("link").InnerText))
                v.Add(vid)
            End If
        Next

        Return New MyList(ID, title, description, created, latestupdate, creator, v.ToArray)

    End Function

    ''' <summary>Gets the video that the specified ID represents.</summary>
    Public Function GetVideo(ID As ID) As Video
        Return Video.FromID(ID)
    End Function

    ''' <summary>Gets the video that the ID at the specified index represents.</summary>
    Public Function GetVideo(Index As Integer) As Video
        If Index < 0 Or Index > Videos.Count Then
            Throw New ArgumentOutOfRangeException()
        End If
        Return GetVideo(Videos(Index))
    End Function

#Region "Properties"

    Private _ID As ID
    ''' <summary>Gets the id of this MyList.</summary>
    Public ReadOnly Property ID As ID
        Get
            Return _ID
        End Get
    End Property

    Private _Title As String
    ''' <summary>Gets the title of this MyList.</summary>
    Public ReadOnly Property Title As String
        Get
            Return _Title
        End Get
    End Property

    Private _Description As String
    ''' <summary>Gets the description of this MyList.</summary>
    Public ReadOnly Property Description As String
        Get
            Return _Description
        End Get
    End Property

    Private _PublishDate As Date
    ''' <summary>Gets the date that this MyList was published.</summary>
    Public ReadOnly Property PublishDate As Date
        Get
            Return _PublishDate
        End Get
    End Property

    Private _LatestUpdate As Date
    ''' <summary>Gets the date this MyList was last updated.</summary>
    Public ReadOnly Property LatestUpdate As Date
        Get
            Return _LatestUpdate
        End Get
    End Property

    Private _Creator As String
    ''' <summary>Gets the name of the creator of this MyList.</summary>
    Public ReadOnly Property Creator As String
        Get
            Return _Creator
        End Get
    End Property

    Private _Videos As ID()
    ''' <summary>Gets the IDs for the videos that this MyList contains.</summary>
    Public ReadOnly Property Videos As ID()
        Get
            Return _Videos
        End Get
    End Property

#End Region

    Public Shared Function GetUri(ID As ID) As Uri
        Return New Uri("http://www.nicovideo.jp/mylist/" + ID.ToString)
    End Function

    ''' <summary></summary>
    Public Shared Function GetAPIUri(ID As ID) As Uri
        Return New Uri(GetUri(ID).OriginalString + "?rss=2.0")
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Cache.RemoveMyList(Me)
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
