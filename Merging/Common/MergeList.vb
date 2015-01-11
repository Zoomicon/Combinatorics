'Version: 20140921
'Author: George Birbilis (birbilis@kagi.com)

Imports Merging.TextUtils

Public Class MergeList
  Implements IList(Of String), IDisposable

#Region "--- Properties ---"

  Public Property Data As IList(Of IList(Of String))
  Public Property Separator As String

  Default Public Property Item(index As Integer) As String Implements System.Collections.Generic.IList(Of String).Item
    Get
      Return Merge(Data(index), Separator)
    End Get
    Set(value As String)
      Data(index) = Split(value, Separator)
    End Set
  End Property

#End Region

#Region "--- Methods ---"

  Public Sub New(ByVal Data As IList(Of IList(Of String)), ByVal Separator As String)
    With Me
      .Data = Data
      .Separator = Separator
    End With
  End Sub

  Public Sub Add(item As String) Implements System.Collections.Generic.ICollection(Of String).Add
    Data.Add(Split(item, Separator))
  End Sub

  Public Sub Clear() Implements System.Collections.Generic.ICollection(Of String).Clear
    Data.Clear()
  End Sub

  Public Function Contains(item As String) As Boolean Implements System.Collections.Generic.ICollection(Of String).Contains
    Return Data.Contains(Split(item, Separator))
  End Function

  Public Sub CopyTo(array() As String, arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of String).CopyTo
    Dim index As Integer = arrayIndex
    For Each item As IList(Of String) In Data
      array(index) = Merge(item, Separator)
      index += 1
    Next
  End Sub

  Public ReadOnly Property Count As Integer Implements System.Collections.Generic.ICollection(Of String).Count
    Get
      Return Data.Count
    End Get
  End Property

  Public ReadOnly Property IsReadOnly As Boolean Implements System.Collections.Generic.ICollection(Of String).IsReadOnly
    Get
      Return Data.IsReadOnly
    End Get
  End Property

  Public Function Remove(item As String) As Boolean Implements System.Collections.Generic.ICollection(Of String).Remove
    Return Data.Remove(Split(item, Separator))
  End Function

  Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of String) Implements System.Collections.Generic.IEnumerable(Of String).GetEnumerator
    Throw New NotImplementedException()
  End Function

  Public Function IndexOf(item As String) As Integer Implements System.Collections.Generic.IList(Of String).IndexOf
    Return Data.IndexOf(Split(item, Separator))
  End Function

  Public Sub Insert(index As Integer, item As String) Implements System.Collections.Generic.IList(Of String).Insert
    Data.Insert(index, Split(item, Separator))
  End Sub

  Public Sub RemoveAt(index As Integer) Implements System.Collections.Generic.IList(Of String).RemoveAt
    Data.RemoveAt(index)
  End Sub

  Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
    Return Data.GetEnumerator()
  End Function

#End Region

#Region "--- IDisposable ---"

  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' dispose managed state (managed objects).
        If GetType(IDisposable).IsInstanceOfType(Data) Then CType(Data, IDisposable).Dispose()
        Data = Nothing
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
