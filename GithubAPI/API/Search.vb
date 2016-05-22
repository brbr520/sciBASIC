﻿Imports System.Collections.Specialized
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Webservices.Github.Class

Namespace API

    Public Module Search

        Public Enum UserSorts
            [default]
            followers
            repositories
            joined
        End Enum

        Public Enum UserSortOrders
            asc
            desc
        End Enum

        ''' <summary>
        ''' [Search users]
        '''
        ''' Find users via various criteria. (This method returns up To 100 results per page.)
        ''' </summary>
        ''' <param name="q">The search terms.</param>
        ''' <param name="sort">
        ''' The sort field. Can be <see cref="UserSorts.followers"/>, <see cref="UserSorts.repositories"></see>, 
        ''' or <see cref="UserSorts.joined"></see>. Default: results are sorted by best match.
        ''' </param>
        ''' <param name="[order]">
        ''' The sort order if sort parameter is provided. One of <see cref="UserSortOrders.asc"/> or 
        ''' <see cref="UserSortOrders.desc"/>. Default: <see cref="UserSortOrders.desc"/>
        ''' </param>
        ''' <returns></returns>
        Public Function Users(q As NameValueCollection,
                              Optional sort As UserSorts = UserSorts.default,
                              Optional [order] As UserSortOrders = UserSortOrders.desc) As SearchResult(Of SearchUser)

        End Function

        Public Structure UsersQuery
            <Term> Public Property term As String
            Public Property type As String
            Public Property [in] As String
            Public Property repos As String
            Public Property location As String
            Public Property language As String
            Public Property created As String
            Public Property followers As String

            Public Overrides Function ToString() As String
                Return Me.GetJson
            End Function
        End Structure
    End Module
End Namespace