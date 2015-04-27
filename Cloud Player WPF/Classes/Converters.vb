Public Class BooleanToVisibilityConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        If CType(value, Boolean) = True Then
            Return Visibility.Visible
        Else
            Return Visibility.Hidden
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        If CType(value, Visibility) = Visibility.Visible Then
            Return True
        Else
            Return False
        End If
    End Function

End Class