Imports System.Xml

Public NotInheritable Class Playlist

#Region "Constructors"

    Sub New(Title As String, Thumbnail As String)
        Me._ID = Guid.NewGuid
        Me._Title = Title
        Me._Thumbnail = Thumbnail
    End Sub

    Sub New(ID As Guid, Title As String, Thumbnail As String, Videos As Video())
        Me._ID = ID
        Me._Title = Title
        Me._Thumbnail = Thumbnail
        _Videos.AddRange(Videos)
    End Sub

#End Region
#Region "Properties and events"

    Public Event CollectionChanged(Playlist As Playlist)

    Public Property ID As Guid
    Public Property Title As String
    Public Property Thumbnail As String

    Private _Videos As New List(Of Video)
    Public ReadOnly Property Videos As IReadOnlyList(Of Video)
        Get
            Return _Videos.AsReadOnly
        End Get
    End Property

#End Region
#Region "Collection"

    Public Function Add(Video As Video) As Video
        _Videos.Add(Video)
        Save()
        RaiseEvent CollectionChanged(Me)
        Return Video
    End Function

    Public Sub AddRange(Videos() As Video)
        _Videos.AddRange(Videos)
        RaiseEvent CollectionChanged(Me)
        Save()
    End Sub

    Public Sub Remove(Video As Video)
        _Videos.Remove(Video)
        Save()
        RaiseEvent CollectionChanged(Me)
    End Sub

    Public Function Contains(Video As Video) As Boolean
        For Each vid In Videos
            If vid Is Video Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function IndexOf(Video As Video) As Integer
        Dim i As Integer = 0
        For Each vid In Videos
            If vid Is Video Then
                Return i
            End If
            i += 1
        Next
        Return -1
    End Function

#End Region
#Region "Functions"

    Public ReadOnly Property Length As TimeSpan
        Get
            Dim i As New TimeSpan
            For Each vid In Videos
                i += vid.Length
            Next
            Return i
        End Get
    End Property

    ''' <summary>Save playlist to disk.</summary>
    Public Sub Save()
        PlaylistGenerator.Save(Me, PlaylistStore.FullName + "\" + Me.ID.ToString + ".xml")
    End Sub

    ''' <summary>Gets the location on disk.</summary>
    Public Function GetLocation() As String
        Return PlaylistStore.FullName + "\" + ID.ToString + ".pl"
    End Function

#End Region

End Class
