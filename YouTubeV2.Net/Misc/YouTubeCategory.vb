Imports System.Xml

Namespace Misc

    ''' <summary>Represents a category on YouTube.</summary>
    Public NotInheritable Class YouTubeCategory
        Implements IDisposable

        Private _Name As String
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property

        Private _DisplayName As String
        Public ReadOnly Property DisplayName As String
            Get
                Return _DisplayName
            End Get
        End Property

        Private _Deprecated As Boolean
        Public ReadOnly Property Deprecated As Boolean
            Get
                Return _Deprecated
            End Get
        End Property

        Private _BrowsableRegions As String()
        Public ReadOnly Property BrowsableRegions As String()
            Get
                Return _BrowsableRegions
            End Get
        End Property

        Private _Language As String
        Public ReadOnly Property Language As String
            Get
                Return _Language
            End Get
        End Property

        Private Sub New(Name As String, DisplayName As String, Language As String, Deprecated As Boolean, BrowsableRegions As String())
            Me._Name = Name
            Me._DisplayName = DisplayName
            Me._Deprecated = Deprecated
            Me._BrowsableRegions = BrowsableRegions
        End Sub

        Public Shared Function GetCategories() As YouTubeCategory()

            Try

                Dim c As New List(Of YouTubeCategory)

                Dim xml As New XmlDocument
                xml.Load(Res.Categories)

                For Each n As XmlElement In xml("app:categories")

                    Dim name As String = n.GetAttribute("term")

                    If Cache.CategoryExists(name) Then
                        c.Add(Cache.GetCategory(name))
                    Else

                        Dim displayname As String = n.GetAttribute("label")
                        Dim language As String = n.GetAttribute("xml:lang")
                        Dim deprecated As Boolean = (n("yt:deprecated") IsNot Nothing)
                        Dim regions As String() = {}

                        If n("yt:browsable") IsNot Nothing Then
                            regions = n("yt:browsable").GetAttribute("regions").Split(" ")
                        End If


                        Dim cat As New YouTubeCategory(name, displayname, language, deprecated, regions)
                        c.Add(cat)
                        Cache.AddCategory(cat)

                    End If

                Next

                Return c.ToArray

            Catch ex As XmlException
            End Try

            Return Nothing

        End Function

        Public Shared Operator =(ByVal Cat1 As YouTubeCategory, Cat2 As YouTubeCategory) As Boolean
            Return (Cat1.Name = Cat2.Name)
        End Operator

        Public Shared Operator <>(ByVal Cat1 As YouTubeCategory, Cat2 As YouTubeCategory) As Boolean
            Return Not (Cat1.Name = Cat2.Name)
        End Operator

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Cache.RemoveCategory(Me)
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

End Namespace


