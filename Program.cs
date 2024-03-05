using System;
using System.Linq;
using ilunnie.Collections;
using ilunnie.Search;

var map = BuildGraph.EUAmap();

var start = map.Nodes.ElementAt(3);
var end = map.Nodes.ElementAt(8);

Console.WriteLine(start.Value);
Console.WriteLine(end.Value);

var found = Search.BFSearch(
    new SearchGraphNode<string>(start),
    end.Value
);

Console.WriteLine(found ? "Goal found" : "Goal not found");