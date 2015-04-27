Public NotInheritable Class Video

#Region "Constructor"

    Public Sub New(Source As Uri, Service As String, Title As String, Uploader As String, Length As TimeSpan, Thumb As String)
        Me.Source = Source
        Me.Service = Service
        Me.Title = Title
        Me.Uploader = Uploader
        Me.Length = Length
        Me._Thumb = Thumb
    End Sub

#End Region
#Region "Properties"

    Public Property Source As Uri
    Public Property Service As String
    Public Property Title As String
    Public Property Uploader As String
    Public Property Length As TimeSpan

    Private _Thumb As String
    Public Property Thumb As String
        Get
            If Not _Thumb.Contains("%ThumbnailStore%") Then
                Return _Thumb
            Else
                Return _Thumb.Replace("%ThumbnailStore", ThumbnailStore.FullName)
            End If
        End Get
        Set(value As String)
            If Not value.Contains(ThumbnailStore.FullName) Then
                _Thumb = value
            Else
                _Thumb = value.Replace(ThumbnailStore.FullName, "%ThumbnailStore%")
            End If
        End Set
    End Property

#End Region
#Region "Functions"

    Public ReadOnly Property FriendlyLength As String
        Get
            Return GetFriendlyLength(Length)
        End Get
    End Property

    Public Shared Function GetFriendlyLength(TimeSpan As TimeSpan) As String
        Return TimeSpan.ToString("HH'h'MM'm'SS's'")
    End Function

#End Region

End Class
