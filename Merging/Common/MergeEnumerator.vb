'Version: 20140921
'Author: George Birbilis (birbilis@kagi.com)

Imports Merging.TextUtils

Public Class MergeEnumerator
  Implements IEnumerator(Of String)

#Region "--- Properties ---"

  Public Property Data As IEnumerator(Of IList(Of String))
  Public Property Separator As String

#End Region

#Region "--- Methods ---"

  Public Sub New(ByVal Data As IEnumerator(Of IList(Of String)), ByVal Separator As String)
    With Me
      .Data = Data
      .Separator = Separator
    End With
  End Sub

  Public ReadOnly Property Current As String Implements System.Collections.Generic.IEnumerator(Of String).Current
    Get
      Return Merge(Data.Current, Separator)
    End Get
  End Property

  Public ReadOnly Property Current1 As Object Implements System.Collections.IEnumerator.Current
    Get
      Return Current
    End Get
  End Property

  Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
    Return Data.MoveNext()
  End Function

  Public Sub Reset() Implements System.Collections.IEnumerator.Reset
    Data.Reset()
  End Sub

#End Region

#Region "--- IDisposable ---"

  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' dispose managed state (managed objects).
        Data.Dispose()
      End If

      ' free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' set large fields to null.

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
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub

#End Region

End Class
