Imports System.Drawing
Imports System.Xml

Namespace Misc

    Public Class Thumbnail

        Public Sub New(Uri As Uri, Optional Size As Size = Nothing, Optional Time As TimeSpan = Nothing)
            Me._Uri = Uri
            Me._Size = Size
            Me._Time = Time
        End Sub

        Public Shared Function ParseAPINode(Xmlnode As XmlElement) As Thumbnail

            Try

                Dim url As String = Xmlnode.GetAttribute("url")
                Dim uri As Uri = New Uri(url)
                Dim size As Size = Nothing
                Dim time As TimeSpan = Nothing

                If Xmlnode.HasAttribute("width") And Xmlnode.HasAttribute("height") Then
                    size = New Size(CInt(Xmlnode.GetAttribute("width")), CInt(Xmlnode.GetAttribute("height")))
                End If

                If Xmlnode.HasAttribute("time") Then
                    time = TimeSpan.Parse(Xmlnode.GetAttribute("time"))
                End If

                Return New Thumbnail(uri, size, time)

            Catch ex As XmlException
                Throw New Misc.YouTubeException("Could not parse thumbnail", ex)
            End Try

        End Function

        Private _Uri As Uri
        Public ReadOnly Property Uri As Uri
            Get
                Return _Uri
            End Get
        End Property

        Private _Size As Size
        Public ReadOnly Property Size As Size
            Get
                Return _Size
            End Get
        End Property

        Private _Time As TimeSpan
        Public ReadOnly Property Time As TimeSpan
            Get
                Return _Time
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return Uri.ToString.Split("\").Last.Split(".").First
            End Get
        End Property

    End Class

End Namespace