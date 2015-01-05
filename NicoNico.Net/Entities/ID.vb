Imports System.Xml

Public Class ID

    Private ID As String

    Private Sub New(IDString As String)
        Me.ID = IDString
    End Sub

    Public Shared Function FromUri(Uri As Uri) As ID
        Return FromIDString(Uri.OriginalString.Split("/").Last.Split("?").First)
    End Function

    Public Shared Function FromIDString(Str As String) As ID
        Return New ID(Str)
    End Function

    ''' <summary>Checks if the id points to a existing video, mylist.</summary>
    Public Function Exists() As Boolean

        Using client As New System.Net.WebClient

            Try
                Dim str As String = client.DownloadString(String.Format(Misc.Res.VideoAPI, ID))
                If Not str = "" Then
                    Return True
                End If
            Catch ex As System.Net.WebException
                'Website does not exist, it is not a video
            End Try

            Try
                Dim str As String = client.DownloadString(MyList.GetAPIUri(Me))
                Dim xml As New XmlDocument
                xml.LoadXml(str)
                Return (xml("nicovideo_thumb_response").GetAttribute("status") = "ok")
            Catch ex As System.Net.WebException
                'Website does not exist, it is not a mylist
            End Try

            Return False

        End Using

    End Function

#Region "Operators"

    Public Overrides Function ToString() As String
        Return ID
    End Function

    Public Shared Operator &(ByVal ID As ID, ByVal Str As String) As String
        Return New String(ID.ToString + Str)
    End Operator

    Public Shared Operator &(ByVal Str As String, ByVal ID As ID) As String
        Return New String(Str + ID.ToString)
    End Operator

    Public Shared Operator +(ByVal ID As ID, ByVal Str As String) As String
        Return New String(ID.ToString + Str)
    End Operator

    Public Shared Operator +(ByVal Str As String, ByVal ID As ID) As String
        Return New String(Str + ID.ToString)
    End Operator

    Public Shared Operator =(ByVal ID1 As ID, ByVal ID2 As ID) As Boolean
        Return (ID1.ToString = ID2.ToString)
    End Operator

    Public Shared Operator <>(ByVal ID1 As ID, ByVal ID2 As ID) As Boolean
        Return Not (ID1 = ID2)
    End Operator

#End Region

End Class
