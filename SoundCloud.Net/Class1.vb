Imports System.Collections.Specialized
Imports System.Text
Imports SoundcloudPlayer.Utility
Imports SoundcloudPlayer.Utility.Http
Imports System.Web
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Json

'//////////////////////////////////////////////
'// Note: THIS CLASS IS MADE BY MAVAMAARTEN~ //
'//   YOU CAN USE THIS WHEREEVER YOU WANT    //
'//    BUT IF YOU DO, GIVE CREDIT TO ME      //
'//         (Mavamaarten~) and idb!          //
'//////////////////////////////////////////////

Public Class User
    <DataMember(Name:="id")>
    Public Property id As Integer
    <DataMember(Name:="kind")>
    Public Property kind As String
    <DataMember(Name:="permalink")>
    Public Property permalink As String
    <DataMember(Name:="username")>
    Public Property username As String
    <DataMember(Name:="uri")>
    Public Property uri As String
    <DataMember(Name:="permalink_url")>
    Public Property permalink_url As String
    <DataMember(Name:="avatar_url")>
    Public Property avatar_url As String
    <DataMember(Name:="country")>
    Public Property country As String
    <DataMember(Name:="full_name")>
    Public Property full_name As String
    <DataMember(Name:="description")>
    Public Property description As String
    <DataMember(Name:="city")>
    Public Property city As String
    <DataMember(Name:="discogs_name")>
    Public Property discogs_name As String
    <DataMember(Name:="myspace_name")>
    Public Property myspace_name As String
    <DataMember(Name:="website")>
    Public Property website As String
    <DataMember(Name:="website_title")>
    Public Property website_title As String
    <DataMember(Name:="online")>
    Public Property online As String
    <DataMember(Name:="track_count")>
    Public Property track_count As String
    <DataMember(Name:="playlist_count")>
    Public Property playlist_count As Integer
    <DataMember(Name:="plan")>
    Public Property plan As String
    <DataMember(Name:="_favorites_count")>
    Public Property _favorites_count As Integer
    <DataMember(Name:="followers_count")>
    Public Property followers_count As Integer
    <DataMember(Name:="followings_count")>
    Public Property followings_count As Integer
    <DataMember(Name:="private_tracks_count")>
    Public Property private_tracks_count As Integer
    <DataMember(Name:="private_playlists_count")>
    Public Property private_playlists_count As Integer
    <DataMember(Name:="primary_email_confirmed")>
    Public Property primary_email_confirmed As Boolean

End Class

<XmlRoot("user")>
Public Class ShortUser
    <XmlElement("id")>
    Public Property id As Integer
    <XmlElement("kind")>
    Public Property kind As String
    <XmlElement("permalink")>
    Public Property permalink As String
    <XmlElement("username")>
    Public Property username As String
    <XmlElement("uri")>
    Public Property uri As String
    <XmlElement("permalink_url")>
    Public Property permalink_url As String
    <XmlElement("avatar_url")>
    Public Property avatar_url As String
End Class

<XmlRoot("track")>
Public Class Track
    <XmlElement("id")>
    Public Property id As Integer
    <XmlElement("created-at")>
    Public Property created_at As String
    <XmlElement("user-id")>
    Public Property user_id As String
    <XmlElement("duration")>
    Public Property duration As Integer
    <XmlElement("commentable")>
    Public Property commentable As String
    <XmlElement("state")>
    Public Property state As String
    <XmlElement("sharing")>
    Public Property sharing As String
    <XmlElement("tag-list")>
    Public Property tag_list As String
    <XmlElement("permalink")>
    Public Property permalink As String
    <XmlElement("description")>
    Public Property description As String
    <XmlElement("streamable")>
    Public Property streamable As String
    <XmlElement("downloadable")>
    Public Property downloadable As String
    <XmlElement("genre")>
    Public Property genre As String
    <XmlElement("release")>
    Public Property release As String
    <XmlElement("purchase-url")>
    Public Property purchase_url As String
    <XmlElement("label-id")>
    Public Property label_id As String
    <XmlElement("label-name")>
    Public Property label_name As String
    <XmlElement("isrc")>
    Public Property isrc As String
    <XmlElement("video-url")>
    Public Property video_url As String
    <XmlElement("track-type")>
    Public Property track_type As String
    <XmlElement("key-signature")>
    Public Property key_signature As String
    <XmlElement("bpm")>
    Public Property bpm As String
    <XmlElement("title")>
    Public Property title As String
    <XmlElement("release-year")>
    Public Property release_year As String
    <XmlElement("release-month")>
    Public Property release_month As String
    <XmlElement("release-day")>
    Public Property release_day As String
    <XmlElement("original-format")>
    Public Property original_format As String
    <XmlElement("original-content-size")>
    Public Property original_content_size As String
    <XmlElement("license")>
    Public Property license As String
    <XmlElement("uri")>
    Public Property uri As String
    <XmlElement("permalink-url")>
    Public Property permalink_url As String
    <XmlElement("artwork-url")>
    Public Property artwork_url As String
    <XmlElement("waveform-url")>
    Public Property waveform_url As String
    <XmlElement("stream-url")>
    Public Property stream_url As String
    <XmlElement("download-url")>
    Public Property download_url As String
    <XmlElement("playback-count")>
    Public Property playback_count As String
    <XmlElement("download_count")>
    Public Property download_count As String
    <XmlElement("favoritings-count")>
    Public Property favoritings_count As String
    <XmlElement("comment-count")>
    Public Property comment_count As String
    Public Property user As ShortUser
End Class

Namespace Service
    Public Class Soundcloud
        Implements IDisposable
        Private Http As Http = Nothing

            Public Const client_ID As String = 'Get one on http://developers.soundcloud.com
            Const client_secret As String = 'Same story here.

#Region "Structures"
        Public Structure Result
            Dim Success As Boolean
            Dim FailMessage As String
            Dim ProxyError As Boolean
            Dim Exception As Exception
        End Structure

        Public Class Song
            Public URL As String
            Public Title As String
            Public Artist As String
            Public LengthInSeconds As Integer
            Public Size As Integer
        End Class
#End Region

#Region "Properties"
        Private _Index As Integer = 0
        Public ReadOnly Property Index As Integer
            Get
                Return _Index
            End Get
        End Property

        Private _Proxy As String = String.Empty
        Public Property Proxy As String
            Get
                Return _Proxy
            End Get
            Set(value As String)
                _Proxy = value
            End Set
        End Property

        Private _Account As String = String.Empty
        Public Property Account As String
            Get
                Return _Account
            End Get
            Set(value As String)
                _Account = value
            End Set
        End Property

        Private _IsLoggedIn As Boolean = False
        Public ReadOnly Property IsLoggedIn As Boolean
            Get
                Return _IsLoggedIn
            End Get
        End Property

        Private _Token As String
        Public ReadOnly Property AccessToken As String
            Get
                Return _Token
            End Get
        End Property
#End Region

#Region "Constructor"
        Public Sub New(I As Integer)
            _Index = I
        End Sub
#End Region

#Region "Deconstructor"
        Private disposedValue As Boolean
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If Not IsNothing(Http) Then Http.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#Region "Methods"

        Private Sub NewSession()
            If Not IsNothing(Http) Then
                Http.Dispose()
                Http = Nothing
            End If
            Http = New Http
            With Http
                .AcceptCharset = String.Empty
                .KeepAlive = True
                .Useragent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:14.0) Gecko/20100101 Firefox/14.0.1"

                .AutoRedirect = True
                .SendCookies = True
                .StoreCookies = True

                If Not String.IsNullOrEmpty(Proxy) Then
                    If Not CountOccurance(Proxy, ":") > 1 Then
                        .Proxy = New HttpProxy(Proxy.Split(Convert.ToChar(":"))(0), Convert.ToInt32(Proxy.Split(Convert.ToChar(":"))(1)))
                    Else
                        .Proxy = New HttpProxy(Proxy.Split(Convert.ToChar(":"))(0), Convert.ToInt32(Proxy.Split(Convert.ToChar(":"))(1)), Proxy.Split(Convert.ToChar(":"))(2), Proxy.Split(Convert.ToChar(":"))(3))
                    End If
                End If
            End With
        End Sub
#End Region

#Region "XML deserialization"

        Private Function ParseTrack(ByVal XML As String) As Track
            Dim track As Track = Nothing
            Try
                Dim encoding As New System.Text.UTF8Encoding
                Dim usr As String = "<user>" & Split(Split(XML, "<user>")(1), "</user>")(0) & "</user>"
                Dim user As ShortUser
                Dim bytes() As Byte = encoding.GetBytes(usr)
                Using os As New MemoryStream
                    os.Write(bytes, 0, bytes.Length)
                    os.Position = 0
                    user = CType(New XmlSerializer(GetType(ShortUser)).Deserialize(os), ShortUser)
                End Using
                XML.Replace(usr, "")
                bytes = encoding.GetBytes(XML)
                Using os As New MemoryStream
                    os.Write(bytes, 0, bytes.Length)
                    os.Position = 0
                    track = CType(New XmlSerializer(GetType(Track)).Deserialize(os), Track)
                    track.user = user
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
            Return track
        End Function

        Private Function ParseUser(ByVal Json As String) As User
            Dim encoding As New System.Text.UTF8Encoding
            Dim bytes() As Byte = encoding.GetBytes(Json)

            Using os As New MemoryStream
                os.Write(bytes, 0, bytes.Length)
                os.Position = 0

                Using reader As New StreamReader(os)
                    Dim converter As New Converter(Of User)
                    Return converter.ReturnJSON(reader)
                End Using
            End Using
        End Function

        Private Class Converter(Of t)
            Public Function ReturnJSON(ByRef sreader As StreamReader) As t
                If GetType(t).Equals(GetType(String)) Then
                    Dim result As Object = sreader.ReadToEnd.Replace("""", "")
                    Return result
                Else
                    Dim ds As New DataContractJsonSerializer(GetType(t))
                    Dim result As t = DirectCast(ds.ReadObject(sreader.BaseStream), t)
                    ds = Nothing
                    Return result
                End If
            End Function
        End Class

#End Region

#Region "API"

        Public Function AuthorizeURL(ByVal Input As String) As String
            Return Input & "?client_id=" & Soundcloud.client_ID & "&oauth_token=" & _Token
        End Function

        Public Function Unlike_Track(ByVal T As Track) As Boolean
            Dim responseFromServer As String
            Try
                Dim request As WebRequest = WebRequest.Create("https://api.soundcloud.com/me/favorites/" & T.id & "?client_id=" & Soundcloud.client_ID & "&oauth_token=" & _Token)
                request.Method = "DELETE"
                Dim postData As String = ""
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                responseFromServer = reader.ReadToEnd()

                reader.Close()
                dataStream.Close()
                response.Close()
            Catch ex As Exception
                If ex.ToString.Contains("404") Then
                    Return True
                Else
                    Return False
                End If
            End Try

            If responseFromServer.Contains("200 - OK") Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function Like_Track(ByVal T As Track) As Boolean
            Dim responseFromServer As String
            Try
                Dim request As WebRequest = WebRequest.Create("https://api.soundcloud.com/me/favorites/" & T.id & "?client_id=" & Soundcloud.client_ID & "&oauth_token=" & _Token)
                request.Method = "PUT"
                Dim postData As String = ""
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                responseFromServer = reader.ReadToEnd()
                reader.Close()
                dataStream.Close()
                response.Close()
            Catch ex As Exception
                Return False
            End Try

            If responseFromServer.Contains("201 - Created") Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function Search(ByVal Query As String) As List(Of Track)
            Dim result As New List(Of Track)
            Try
                Dim Response As String = New WebClient() With {.Proxy = Nothing}.DownloadString("https://api.soundcloud.com/tracks.xml" & "?limit=500&q=" & UrlEncode(Query) & "&client_id=" & client_ID)

                For Each trck As String In Split(Response, "<track>")
                    If Not trck.Contains("kind") Then Continue For
                    trck = "<track>" & trck
                    If trck.Contains("</tracks>") Then trck = Split(trck, "</tracks>")(0)
                    result.Add(ParseTrack(trck))
                Next
                Return result
            Catch ex As Exception
                Return result
            End Try
        End Function

        Public Function Get_Activity() As List(Of Track)
            Dim result As New List(Of Track)
            Try
                Dim Response As String = New WebClient() With {.Proxy = Nothing}.DownloadString("https://api.soundcloud.com/me/activities/tracks/affiliated" & "?limit=50&oauth_token=" & _Token)
                For Each trck As String In Split(Response, "<activity>")
                    If Not trck.Contains("kind") Then Continue For
                    If trck.Contains("<type>track-sharing</type>") Then Continue For

                    trck = Split(trck, "<origin>")(1)
                    trck = Split(trck, "</origin>")(0)
                    trck = "<track>" & trck & "</track>"

                    result.Add(ParseTrack(trck))
                Next
                Return result
            Catch ex As Exception
                Return result
            End Try

        End Function

        Public Function Get_Favorites() As List(Of Track)
            Dim result As New List(Of Track)
            Try
                Dim Response As String = New WebClient() With {.Proxy = Nothing}.DownloadString("https://api.soundcloud.com/me/favorites.xml" & "?limit=500&oauth_token=" & _Token)

                For Each trck As String In Split(Response, "<track>")
                    If Not trck.Contains("kind") Then Continue For
                    trck = "<track>" & trck
                    If trck.Contains("</tracks>") Then trck = Split(trck, "</tracks>")(0)

                    Dim resultTrack As Track = ParseTrack(trck)
                    If Not resultTrack.id = 0 Then result.Add(resultTrack)
                Next
                Return result
            Catch ex As Exception
                Return result
            End Try
        End Function

        Public Function Get_CurrentUserTracks() As List(Of Track)
            Dim result As New List(Of Track)
            Try
                Dim Response As String = New WebClient() With {.Proxy = Nothing}.DownloadString("https://api.soundcloud.com/me/tracks.xml" & "?limit=500&oauth_token=" & _Token)
                For Each trck As String In Split(Response, "<track>")
                    If Not trck.Contains("kind") Then Continue For
                    trck = "<track>" & trck
                    If trck.Contains("</tracks>") Then trck = Split(trck, "</tracks>")(0)

                    Dim resultTrack As Track = ParseTrack(trck)
                    If Not resultTrack.id = 0 Then result.Add(resultTrack)
                Next
                Return result
            Catch ex As Exception
                Return result
            End Try
        End Function

        Public Function Get_Current_User() As User
            If Not _IsLoggedIn Then
                Throw New Exception("Not logged in")
                Exit Function
            End If

            Return ParseUser(New WebClient() With {.Proxy = Nothing}.DownloadString("https://api.soundcloud.com/me.json" & "?oauth_token=" & _Token))
        End Function

        Public Function Login() As Result
            Dim Result As New Result
            Try
                NewSession()
                With Http
                    .TimeOut = 10000
                    .RedirectBlacklist.Add("badbrowser.php")


                    Dim PostData As New StringBuilder
                    PostData.Append("client_id=" & client_ID)
                    PostData.Append("&client_secret=" & client_secret)
                    PostData.Append("&grant_type=password&username=" & UrlEncode(_Account.Split(":")(0)))
                    PostData.Append("&password=" & UrlEncode(_Account.Split(":")(1)))

                    .Referer = "http://www.soundcloud.com"
                    Dim hr As SoundcloudPlayer.Utility.Http.HttpResponse = .GetResponse(Verb._POST, "https://api.soundcloud.com/oauth2/token", PostData.ToString)
                    If Not IsNothing(hr.RequestError) Then
                        Result.Exception = DirectCast(hr.RequestError.Exception, Exception)
                        Result.ProxyError = hr.RequestError.IsProxyError
                        Result.FailMessage = "Could not submit log in credentials; " & hr.RequestError.Message
                        Exit Try
                    ElseIf Not hr.Html.Contains("access_token") Then
                        Result.Exception = Nothing
                        Result.ProxyError = False
                        Result.FailMessage = "Could not get access token. Wrong credentials?"
                        Exit Try
                    End If


                    Dim m As Match = New Regex(".*?" & """.*?""" & ".*?" & "("".*?"")", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Match(hr.Html)
                    If (m.Success) Then
                        _Token = m.Groups(1).Value.Replace(Chr(34), "")
                    Else
                        Result.Exception = Nothing
                        Result.ProxyError = False
                        Result.FailMessage = "Could not get access token. Wrong credentials?"
                        Exit Try
                    End If

                End With
            Catch ex As Exception
                Result.Exception = ex
                Result.FailMessage = "Function exception; " & ex.Message
            Finally
                Result.Success = String.IsNullOrEmpty(Result.FailMessage)
                _IsLoggedIn = True
            End Try
            Return Result
        End Function
#End Region
    End Class
End Namespace