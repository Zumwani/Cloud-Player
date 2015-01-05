Public Class Cache

    Private Shared Videos As New List(Of Video)
    Private Shared MyLists As New List(Of MyList)

    Friend Shared Function GetVideo(ID As ID) As Video
        For Each v In Videos
            If v.ID = ID Then
                Return v
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Function GetMyList(ID As ID) As MyList
        For Each ml In MyLists
            If ml.ID = ID Then
                Return ml
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Sub AddVideo(Video As Video)
        If Not VideoExists(Video.ID) Then
            Videos.Add(Video)
        End If
    End Sub

    Friend Shared Sub AddMyList(MyList As MyList)
        If Not VideoExists(MyList.ID) Then
            MyLists.Add(MyList)
        End If
    End Sub

    Friend Shared Sub RemoveVideo(Video As Video)
        If VideoExists(Video.ID) Then
            Videos.Remove(Video)
        End If
    End Sub

    Friend Shared Sub RemoveMyList(MyList As MyList)
        If VideoExists(MyList.ID) Then
            MyLists.Remove(MyList)
        End If
    End Sub

    Friend Shared Function VideoExists(ID As ID) As Boolean
        For Each v In Videos
            If v.ID = ID Then Return True
        Next
        Return False
    End Function

    Friend Shared Function MyListExists(ID As ID) As Boolean
        For Each ml In MyLists
            If ml.ID = ID Then Return True
        Next
        Return False
    End Function

    ''' <summary>Clears the cache, removing all references to videos, mylists and users.</summary>
    Public Shared Sub Clear()
        Videos.Clear()
        MyLists.Clear()
    End Sub

End Class
