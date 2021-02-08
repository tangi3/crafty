using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class Node
{
	public int id, Z;

	//can receive data from parents
	//always as string. Can be parsed if needed.
	private Dictionary<int, string> requests;

	//childs
	public Dictionary<int, Node> childs;

	public Vector2 position = new Vector2(0, 0);

	//used to send data to all child nodes (broadcasting)
	public delegate void sendDelegate(string data, Node child);
	private delegate void afterReceiveDelegate();

	private sendDelegate callback_send;
	private afterReceiveDelegate callback_afterReceive;

	//every node can be drawn
	public Texture2D texture;
	public Rectangle destination;
	public Rectangle part;
	public Color[] data;

	public Node(int ID)
	{
		id = ID;

		childs = new Dictionary<int, Node>();

		callback_send = new sendDelegate(_send);
		callback_afterReceive = new afterReceiveDelegate(_afterReceive);

		requests = new Dictionary<int, string>();

		part = new Rectangle((int)position.X, (int)position.Y, 0, 0);
	}

	//id should be retrieved from child.id
	public void Add(int id, Node child){ childs.Add(id, child); }

	public void broadcast(string data) { foreach (Node item in childs.Values) { callback_send(data, item); } }

	public void _send(string datastr, Node child)
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

	//load texture from monogame content pipeline
	public void loadFromPipeline(ContentManager content, string path) { texture = content.Load<Texture2D>(path); }

	//Draw the whole image
	public void Draw(ref SpriteBatch spriteBatch)
	{
		destination.X = (int)position.X;
		destination.Y = (int)position.Y;

		spriteBatch.Draw(texture, destination, Color.White);
	}

	//Draw the whole image
	public void Draw(ref SpriteBatch spriteBatch, int width, int height)
	{
		destination.X = (int)position.X;
		destination.Y = (int)position.Y;
		destination.Width = width;
		destination.Height = height;

		spriteBatch.Draw(texture, destination, Color.White);
	}

	//Draw a tile
	public void Draw(ref SpriteBatch spriteBatch, int rectangleX, int rectangleY, int width, int height)
	{
		destination.X = (int)position.X;
		destination.Y = (int)position.Y;
		destination.Width = width;
		destination.Height = height;

		part.X = rectangleX;
		part.Y = rectangleX;
		part.Width = width;
		part.Height = height;

		spriteBatch.Draw(texture, destination, part, Color.White);
	}

	//Draw a tile
	public void Draw(ref SpriteBatch spriteBatch, float x, float y, int rectangleX, int rectangleY, int width, int height)
    {
		position.X = x;
		position.Y = y;

		destination.X = (int)position.X;
		destination.Y = (int)position.Y;
		destination.Width = width;
		destination.Height = height;

		part.X = rectangleX;
		part.Y = rectangleY;
		part.Width = width;
		part.Height = height;

		spriteBatch.Draw(texture, destination, part, Color.White);
	}

	//get the part you want from the image
	//will be used for sprites
	private Texture2D GetPart()
	{
		texture = new Texture2D(texture.GraphicsDevice, part.Width, part.Height);
		data = new Color[part.Width * part.Height];
		texture.GetData<Color>(0, part, data, 0, data.Length);
		texture.SetData<Color>(data);
		return texture;
	}

	virtual public void _update(Node parent)
	{
		//code that need to be executed in game update function
	}

	virtual public void _set(float x, float y, int width, int height) { }
}
