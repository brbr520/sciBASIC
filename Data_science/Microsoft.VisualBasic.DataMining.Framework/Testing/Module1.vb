﻿Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream
Imports Microsoft.VisualBasic.DataMining.KMeans.NodeTrees

Module Module1
    Sub Main()
        Dim tree = Network.Load("G:\Xanthomonas_campestris_8004_uid15\genome\palindrome-motifs\palindrome_promoter=-250bp-cut=0.65,minw=6\binary-net").BuildTree
        Dim parts = tree.CutTrees.ToArray

        Pause()
    End Sub
End Module