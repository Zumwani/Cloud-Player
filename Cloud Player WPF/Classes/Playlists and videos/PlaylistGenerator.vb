Imports System.Xml
Imports System.IO
Imports System.Reflection

Public Class PlaylistGenerator

#Region "Generator"

    Public Const GeneratorVersion As String = "1.0.0.0"

    Public Shared Function GenerateXml(Playlist As Playlist) As XmlDocument
        With Playlist

            Dim videosource As New Dictionary(Of Integer, Uri)
            Dim videoservice As New Dictionary(Of Integer, String)
            Dim videotitle As New Dictionary(Of Integer, String)
            Dim videouploader As New Dictionary(Of Integer, String)
            Dim videolength As New Dictionary(Of Integer, TimeSpan)
            Dim videothumb As New Dictionary(Of Integer, String)

            Dim i As Integer = 0
            For Each vid In .Videos
                videosource.Add(i, vid.Source)
                videoservice.Add(i, vid.Service)
                videotitle.Add(i, vid.Title)
                videouploader.Add(i, vid.Uploader)
                videolength.Add(i, vid.Length)
                videothumb.Add(i, vid.Thumb)
                i += 1
            Next

            Return (GenerateXml(.Title, .ID, .Thumbnail, videosource, videoservice, videotitle, videouploader, videolength, videothumb))

        End With
    End Function

    Private Shared Function GenerateXml(Title As String, ID As Guid, Thumb As String, videosource As Dictionary(Of Integer, Uri), videoservice As Dictionary(Of Integer, String), videotitle As Dictionary(Of Integer, String), videocreator As Dictionary(Of Integer, String), videolength As Dictionary(Of Integer, TimeSpan), videothumb As Dictionary(Of Integer, String)) As XmlDocument

        Dim xml As New XmlDocument

        'Create root node
        Dim rootnode As XmlNode = xml.AppendChild(xml.CreateElement("Playlist"))

        'Add the generator version attribute
        Dim at As XmlAttribute = xml.CreateAttribute("PlaylistGeneratorVersion")
        at.InnerText = GeneratorVersion
        rootnode.Attributes.Append(at)

        Dim titlenode As XmlNode = rootnode.AppendChild(xml.CreateElement("Title"))
        Dim idnode As XmlNode = rootnode.AppendChild(xml.CreateElement("ID"))
        Dim thumbnode As XmlNode = rootnode.AppendChild(xml.CreateElement("Thumb"))

        titlenode.InnerText = Title
        idnode.InnerText = ID.ToString
        thumbnode.InnerText = Thumb

        Dim videosnode As XmlNode = rootnode.AppendChild(xml.CreateElement("Videos"))

        For i As Integer = 0 To videosource.Count - 1

            Dim node As XmlNode = videosnode.AppendChild(xml.CreateElement("Video"))

            Dim sourcenode As XmlNode = node.AppendChild(xml.CreateElement("Source"))
            Dim servicenode As XmlNode = node.AppendChild(xml.CreateElement("Service"))
            Dim vtitlenode As XmlNode = node.AppendChild(xml.CreateElement("Title"))
            Dim uploadernode As XmlNode = node.AppendChild(xml.CreateElement("Uploader"))
            Dim lengthnode As XmlNode = node.AppendChild(xml.CreateElement("Length"))
            Dim vthumbnode As XmlNode = node.AppendChild(xml.CreateElement("Thumb"))

            sourcenode.InnerText = videosource(i).ToString
            servicenode.InnerText = videoservice(i)
            vtitlenode.InnerText = videotitle(i)
            uploadernode.InnerText = videocreator(i)
            lengthnode.InnerText = videolength(i).ToString
            thumbnode.InnerText = videothumb(i)

        Next

        Return xml

    End Function

    Private Shared Function ParseXml(XmlDocument As XmlDocument, Source As Uri) As Playlist

        Dim ver As String = GetGeneratorVersionOfPlaylist(XmlDocument)

        Try

            'Check if the generator version is supported
            If CheckGeneratorVersion(XmlDocument) = False Then
                Throw New ParseException("Playlist was generated with a different version than the current.", Source, GeneratorVersion, ver, New NotImplementedException)
            End If

            Dim title As String = DecodeXML(XmlDocument("Playlist")("Title").InnerText)
            Dim id As Guid = Guid.Parse(XmlDocument("Playlist")("ID").InnerText)
            Dim thumb As String = DecodeXML(XmlDocument("Playlist")("Thumb").InnerText)

            Dim videos As New List(Of Video)

            For Each node As XmlNode In XmlDocument("Playlist")("Videos")

                Dim videosource As String = node("Source").InnerText
                Dim videoservice As String = DecodeXML(node("Service").InnerText)
                Dim videotitle As String = node("Title").InnerText
                Dim videouploader As String = DecodeXML(node("Uploader").InnerText)
                Dim videolength As TimeSpan = TimeSpan.Parse(node("Length").InnerText)
                Dim videothumbnail As String = DecodeXML(node("Thumb").InnerText)

                videos.Add(New Video(New Uri(videosource), videoservice, videotitle, videouploader, videolength, videothumbnail))

            Next

            Return New Playlist(id, title, thumb, videos.ToArray)

        Catch e As NullReferenceException
            'The xml is probably not a valid playlist file
            Log.Write("PlaylistManager", e.Message)
            Throw New ParseException("The file was not of a valid playlist format.", Source, GeneratorVersion, ver, e)
        Catch ex As XmlException
            'The xml file could not be parsed
            Log.Write("PlaylistManager", ex.Message)
            Throw New ParseException("The file was not of a valid playlist format.", Source, GeneratorVersion, ver, ex)
        Catch ex1 As NotSupportedException
            'The file was created with a other version of the generator than the current one.
            Log.Write("PlaylistManager", ex1.Message)
            Throw New ParseException("The file was created with a different generator version than the current one.", Source, GeneratorVersion, ver, ex1)
        End Try

    End Function

    Private Shared Function DecodeXML(ByVal s As String) As String
        If Len(s) = 0 Then Return String.Empty
        Dim decodedString As String = String.Empty
        Dim readersettings = New System.Xml.XmlReaderSettings
        readersettings.ConformanceLevel = Xml.ConformanceLevel.Fragment
        Dim ms = New System.IO.StringReader(s)
        Using reader = System.Xml.XmlReader.Create(ms, readersettings)
            reader.MoveToContent()
            decodedString = reader.ReadString
        End Using
        Return decodedString
    End Function

#End Region
#Region "Functions"

    Public Shared Function Load(Source As Uri) As Playlist

        'Validate the file before continuing
        Try
            If ValidateFile(Source, True) = False Then
                Return Nothing
            End If
        Catch ex As FileNotFoundException
            'File does not exist
            Throw New ParseException(Locale.Locale.FileNotFound, Source, GeneratorVersion, Locale.Locale.Unknown, ex)
        Catch ex1 As ArgumentException
            'File does not have correct fileextension
            Throw New ParseException(Locale.Locale.FileWasNotOfProperPlatlistFormat, Source, GeneratorVersion, Locale.Locale.Unknown, ex1)
        End Try

        Try

            'Load document
            Dim xml As New XmlDocument
            xml.Load(Source.LocalPath)

            Return ParseXml(xml, Source)

        Catch ex As ParseException
            'An error occured while parsing
            Throw ex
        Catch ex1 As XmlException
            'Could not load file as xml
            Throw New ParseException(Locale.Locale.FileWasNotOfProperPlatlistFormat, Source, GeneratorVersion, Locale.Locale.Unknown, ex1)
        End Try

        Return Nothing

    End Function

    Public Shared Sub Save(Playlist As Playlist, Filename As String)
        With Playlist
            Dim xml As XmlDocument = GenerateXml(Playlist)
            xml.Save(Filename)
        End With
    End Sub

    Private Shared Function GetGeneratorVersionOfPlaylist(XmlDocument As XmlDocument) As String

        Dim fileversion As String = Locale.Locale.Unknown

        If XmlDocument("Playlist").GetAttribute("PlaylistGeneratorVersion") IsNot Nothing Then
            fileversion = XmlDocument("Playlist").GetAttribute("PlaylistGeneratorVersion")
        End If

        Return fileversion

    End Function

    Private Shared Function ValidateFile(Source As Uri, ThrowOnError As Boolean) As Boolean

        If Not File.Exists(Source.LocalPath) Then
            If ThrowOnError Then
                Throw New FileNotFoundException
            Else
                Return False
            End If
        End If

        If Not Path.GetExtension(Source.LocalPath) = ".xml" Then

            If ThrowOnError Then
                Throw New ArgumentException
            Else
                Return False
            End If

        End If

        Return True

    End Function

    Private Shared Function CheckGeneratorVersion(Xml As XmlDocument) As Boolean
        If Xml("Playlist") IsNot Nothing Then
            Dim ver As String = Xml("Playlist").GetAttribute("PlaylistGeneratorVersion")
            Return (ver = GeneratorVersion)
        End If
        Return False
    End Function

#End Region
#Region "ParseException"

    Public Class ParseException
        Inherits Exception

        Private _GeneratorVersion As String
        Public ReadOnly Property GeneratorVersion As String
            Get
                Return _GeneratorVersion
            End Get
        End Property

        Private _PlaylistVersion As String
        Public ReadOnly Property PlaylistVersion As String
            Get
                Return _PlaylistVersion
            End Get
        End Property

        Private _Source As Uri
        Public ReadOnly Property Source As Uri
            Get
                Return _Source
            End Get
        End Property

        Sub New(Message As String, Source As Uri, GeneratorVersion As String, PlaylistVersion As String, InnerException As Exception)
            MyBase.New(Message, InnerException)
            _Source = Source
            _GeneratorVersion = GeneratorVersion
            _PlaylistVersion = PlaylistVersion
        End Sub

    End Class

#End Region
#Region "Upgrade"

    Public Shared Sub UpgradePlaylist(Source As Uri)

        Try

            Dim xml As New XmlDocument
            xml.Load(Source.LocalPath)

            IO.File.Move(Source.LocalPath, BackupDir.FullName + "\" + Path.GetExtension(Source.LocalPath))

            xml = UpgradePlaylist(xml)
            xml.Save(Source.LocalPath)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Shared Function UpgradePlaylist(XmlDocument As XmlDocument) As XmlDocument
        'TODO: Move out of source code (xml template document?)

        'Declare properties of current version
        Dim title As String = ""
        Dim id As Guid = Nothing
        Dim thumb As String = ""

        Dim videosource As New Dictionary(Of Integer, Uri)
        Dim videoservice As New Dictionary(Of Integer, String)
        Dim videotitle As New Dictionary(Of Integer, String)
        Dim videouploader As New Dictionary(Of Integer, String)
        Dim videolength As New Dictionary(Of Integer, TimeSpan)
        Dim videothumb As New Dictionary(Of Integer, String)

        Dim version As String = GetGeneratorVersionOfPlaylist(XmlDocument)

        'Get values
        Select Case version

            Case Is = "1.0.0.0"

                title = GetTextFromNode(XmlDocument("Playlist")("Title"))
                Guid.TryParse(GetTextFromNode(XmlDocument("Playlist")("ID")), id)
                thumb = GetTextFromNode(XmlDocument("Playlist")("Thumb"))

                Dim i As Integer = 0
                For Each Video As XmlNode In XmlDocument("Playlist")("Videos")
                    videosource.Add(i, New Uri(GetTextFromNode(Video("Source"))))
                    videoservice.Add(i, GetTextFromNode(Video("Service")))
                    videotitle.Add(i, GetTextFromNode(Video("Title")))
                    videouploader.Add(i, GetTextFromNode(Video("Uploader")))
                    videothumb.Add(i, GetTextFromNode(Video("Thumb")))

                    Dim ts As TimeSpan
                    If TimeSpan.TryParse(GetTextFromNode(Video("Length")), ts) = True Then
                        videolength.Add(i, ts)
                    Else
                        videolength.Add(i, Nothing)
                    End If

                    i += 1

                Next

        End Select

        'Generate new xmldocument using the values
        Dim Xml As XmlDocument = GenerateXml(title, id, thumb, videosource, videoservice, videotitle, videouploader, videolength, videothumb)
        Return Xml

    End Function

    ''' <summary>Returns the text of an node, returns "" if node does not exist.</summary>
    Private Shared Function GetTextFromNode(XmlNode As XmlNode) As String
        Dim str As String = ""
        If XmlNode IsNot Nothing Then
            str = DecodeXML(XmlNode.InnerText)
        End If
        Return str
    End Function

#End Region

End Class
