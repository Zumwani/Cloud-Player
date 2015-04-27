Imports System.IO
Imports System.Globalization

Module Module1

    'Moves all localization resources to the Language subfolder

    Sub Main(args As String())

        If Not args.Count = 0 Then

            'Directory has to be specified as first argument
            Dim dir As New DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\" + args(0))

            If dir.Exists Then

                'Get all country codes
                Dim cultures As String() = Array.ConvertAll(Of CultureInfo, String)(CultureInfo.GetCultures(CultureTypes.AllCultures), Function(x As CultureInfo) x.ToString)

                'Define destination dir (%outputpath%\Languages)
                Dim destDir As New DirectoryInfo(dir.FullName + "\Languages")

                'Delete destination dir if it exists to ensure that the newest files are moved
                If destDir.Exists Then
                    destDir.Delete(True)
                End If

                destDir.Create()

                If dir.Exists Then

                    'Loop through all folders in specfied path and if any matches a country code, then move it.
                    For Each subdir In dir.GetDirectories
                        If cultures.Contains(subdir.Name) Then
                            subdir.MoveTo(destDir.FullName + "\" + subdir.Name)
                        End If
                    Next

                End If

            End If

        End If

    End Sub

End Module
