Imports YouTube.Net.Misc
Imports System.Net
Imports System.Collections.Specialized
Imports System.Xml
Imports System.Runtime.Serialization.Json

Public Class YouTubeClient

    Public Property ClientID As String
    Public Property ClientSecret As String

    Private _AccessToken As String
    Public ReadOnly Property AccessToken As String
        Get
            Return _AccessToken
        End Get
    End Property

    Public ReadOnly Property IsAutenticated As Boolean
        Get
            'TODO: Verify that token is still valid
            Return Not (AccessToken = "")
        End Get
    End Property

    Sub New()
    End Sub

    Sub New(ClientID As String, ClientSecret As String)
        Me.ClientID = ClientID
        Me.ClientSecret = ClientSecret
    End Sub

    Public Function _Authenticate() As String

        If ClientID = "" Then
            Throw New ArgumentException
        End If

        If ClientSecret = "" Then
            Throw New ArgumentException
        End If

        Dim d As New AuthenticateDialog
        Dim authtoken As String = d.ShowDialog(ClientID, Scope.Full)

        If Not authtoken = "" Then

            Using client As New WebClient

                Dim coll As New NameValueCollection

                coll.Add("code", authtoken)
                coll.Add("client_id", ClientID)
                coll.Add("client_secret", ClientSecret)
                coll.Add("redirect_uri", Res.Redirect_Uri)
                coll.Add("grant_type", "authorization_code")

                Dim b As Byte() = client.UploadValues("https://accounts.google.com/o/oauth2/token", coll)

                Using jsonreader As XmlDictionaryReader = JsonReaderWriterFactory.CreateJsonReader(b, New XmlDictionaryReaderQuotas)
                    Dim xml As New XmlDocument
                    xml.Load(jsonreader)
                    MsgBox(xml("root")("access_token").InnerText)
                End Using

            End Using

        End If


        'If Not authtoken = "" Then
        '    _AccessToken = token
        '    Return token
        'Else
        '    Return ""
        'End If

    End Function

    Public Function Authenticate() As Boolean
        Return (Not _Authenticate() = "")
    End Function

    Public Function GetVideo(ID As String) As YouTubeVideo

    End Function

    Public Enum Scope
        ''' <summary>Specifies you want to manage a YouTube account</summary>
        Full = 1
        ''' <summary>Specifies you want to view a YouTube account</summary>
        Read_only = 2
        ''' <summary>Specifies you want to upload videos to and manage videos of an YouTube account</summary>
        Upload = 3
        ''' <summary>Specifies you want to retrieve the auditDetails part in a channel resource</summary>
        Audit = 4
    End Enum

    Public Shared Function GetScopeString(Scope As Scope) As String
        Select Case Scope
            Case Is = YouTubeClient.Scope.Full
                Return Res.ScopeString_Full
            Case Is = YouTubeClient.Scope.Read_only
                Return Res.ScopeString_ReadOnly
            Case Is = YouTubeClient.Scope.Upload
                Return Res.ScopeString_Upload
            Case Is = YouTubeClient.Scope.Audit
                Return Res.ScopeString_Audit
            Case Else
                Return ""
        End Select
    End Function

    Public Function [My]()

    End Function

End Class
