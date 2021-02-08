using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using MonoGame.UI.Forms;

public class UIControls : ControlManager
{
    public UIControls(Game game) : base(game)
    {
    }

    public override void InitializeComponent()
    {
        var btn1 = new Button()
        {
            Text = "TEST",
            Size = new Vector2(200, 50),
            BackgroundColor = Color.DarkGreen,
            Location = new Vector2(200, 200)
        };

        btn1.Clicked += Btn1_clicked;
        Controls.Add(btn1);
    }

    private void Btn1_clicked(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        btn.Text = "Clicked !";
    }
}
