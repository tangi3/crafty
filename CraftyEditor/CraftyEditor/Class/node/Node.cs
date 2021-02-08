using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class Node
{
	public int id;

	//can receive data from parents
	//always as string. Can be parsed if needed.
	private Dictionary<int, string> requests;

	//childs
	private Dictionary<int, Node> childs;

	//relative position in the parent node
	public Vector2 position = new Vector2(0, 0);

	//used to send data to all child nodes (broadcasting)
	public delegate void sendDelegate(string data, Node child);
	private delegate void afterReceiveDelegate();

	private sendDelegate callback_send;
	private afterReceiveDelegate callback_afterReceive;

	public Node(int ID)
	{
		id = ID;

		childs = new Dictionary<int, Node>();

		callback_send = new sendDelegate(send);
		callback_afterReceive = new afterReceiveDelegate(_afterReceive);

		requests = new Dictionary<int, string>();

	}

	//id should be retrieved from child.id
	public void Add(int id, Node child){ childs.Add(id, child); }

	public void broadcast(string data) { foreach (Node item in childs.Values) { callback_send(data, item); } }

	public void send(string datastr, Node child)
    {
		Console.WriteLine("Data sent to <Node " + child.id + ">");
		child.receive(id, datastr);
	}

	public void receive(int id, string data)
	{
		requests.Add(id, data);
		callback_afterReceive();
	}

	public void _afterReceive()
    {
		Console.WriteLine("<Node " + id + "> received data");
	}

	//listen for signals
	public bool hasRequest()
    {
		return requests.Count > 0;
	}
}
