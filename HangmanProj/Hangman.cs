using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Runtime.Remoting;
using HangmanProj.Properties;
using System.CodeDom;

namespace HangmanProj
{
    public partial class Hangman : Form
    {
        // An enum is a form of a class which holds constants which are unchangable and read only.
        enum CurrentState
        {
            // start game with nothing showing add pillar and each body part from there
            None,
            Piller,
            Rope,
            Head,
            Body,
            LeftArm,
            RightArm,
            RightLeg,
            LeftLeg
        }

        // create array of words
        string[] words = {"sheep","goat","computer","elephant","giraff","america","watermelon","icecream","jasmine","pineapple","orange","mango","chicken","turkey","beans","potatoes",
            "sharp","needle","clothing","vacation" };
        // create list to hold the characters of current word;
        List<Label> labels = new List<Label>();
        // the current word for the game
        public string CurrentWord { get; set; }
        // the default character placeholder for the hidden letters
        public string DefaultChar { get { return "___"; } }
        // the current state of hangman
        // change image displayed as game progresses
        private CurrentState CurrHangState = CurrentState.None;
        // Size of the enum for hangstate
        public int HangStateSize { get { return (Enum.GetValues(typeof(CurrentState)).Length - 1); } }
        // Size of the enum for hangstate

        public static object Properties { get; private set; }

        private readonly Bitmap[] hangImages = { HangmanProj.Properties.Resources.Art1, HangmanProj.Properties.Resources.Art2, HangmanProj.Properties.Resources.Art3,
            HangmanProj.Properties.Resources.Art4, HangmanProj.Properties.Resources.Art5, HangmanProj.Properties.Resources.Art6,
            HangmanProj.Properties.Resources.Art7, HangmanProj.Properties.Resources.none };

        public Bitmap[] GetHangImages()
        {
            return hangImages;
        }

        public int PanelLocX { get => panelLocX; set => panelLocX = value; }
        public int WrongGuesses { get; private set; }
        public override bool AllowDrop { get => base.AllowDrop; set => base.AllowDrop = value; }
        public override AnchorStyles Anchor { get => base.Anchor; set => base.Anchor = value; }
        public override Point AutoScrollOffset { get => base.AutoScrollOffset; set => base.AutoScrollOffset = value; }

        public override LayoutEngine LayoutEngine => base.LayoutEngine;

        public override Image BackgroundImage { get => base.BackgroundImage; set => base.BackgroundImage = value; }
        public override ImageLayout BackgroundImageLayout { get => base.BackgroundImageLayout; set => base.BackgroundImageLayout = value; }

        protected override bool CanRaiseEvents => base.CanRaiseEvents;

        public override ContextMenu ContextMenu { get => base.ContextMenu; set => base.ContextMenu = value; }
        public override ContextMenuStrip ContextMenuStrip { get => base.ContextMenuStrip; set => base.ContextMenuStrip = value; }
        public override Cursor Cursor { get => base.Cursor; set => base.Cursor = value; }

        protected override Cursor DefaultCursor => base.DefaultCursor;

        protected override Padding DefaultMargin => base.DefaultMargin;

        protected override Size DefaultMaximumSize => base.DefaultMaximumSize;

        protected override Size DefaultMinimumSize => base.DefaultMinimumSize;

        protected override Padding DefaultPadding => base.DefaultPadding;

        public override DockStyle Dock { get => base.Dock; set => base.Dock = value; }
        protected override bool DoubleBuffered { get => base.DoubleBuffered; set => base.DoubleBuffered = value; }

        public override bool Focused => base.Focused;

        public override Font Font { get => base.Font; set => base.Font = value; }
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }
        public override RightToLeft RightToLeft { get => base.RightToLeft; set => base.RightToLeft = value; }

        protected override bool ScaleChildren => base.ScaleChildren;

        public override ISite Site { get => base.Site; set => base.Site = value; }

        protected override bool ShowKeyboardCues => base.ShowKeyboardCues;

        protected override bool ShowFocusCues => base.ShowFocusCues;

        protected override ImeMode ImeModeBase { get => base.ImeModeBase; set => base.ImeModeBase = value; }

        public override Rectangle DisplayRectangle => base.DisplayRectangle;

        public override BindingContext BindingContext { get => base.BindingContext; set => base.BindingContext = value; }

        protected override bool CanEnableIme => base.CanEnableIme;

        public override Size AutoScaleBaseSize { get => base.AutoScaleBaseSize; set => base.AutoScaleBaseSize = value; }
        public override bool AutoScroll { get => base.AutoScroll; set => base.AutoScroll = value; }
        public override bool AutoSize { get => base.AutoSize; set => base.AutoSize = value; }
        public override AutoValidate AutoValidate { get => base.AutoValidate; set => base.AutoValidate = value; }
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        protected override CreateParams CreateParams => base.CreateParams;

        protected override ImeMode DefaultImeMode => base.DefaultImeMode;

        protected override Size DefaultSize => base.DefaultSize;

        public override Size MaximumSize { get => base.MaximumSize; set => base.MaximumSize = value; }
        public override Size MinimumSize { get => base.MinimumSize; set => base.MinimumSize = value; }
        public override bool RightToLeftLayout { get => base.RightToLeftLayout; set => base.RightToLeftLayout = value; }

        protected override bool ShowWithoutActivation => base.ShowWithoutActivation;

        public override string Text { get => base.Text; set => base.Text = value; }

        // Global graphics data
        Pen p;
        Pen pRope;
        int panelLocX = 0;
        int panelLocY = 0;
        int panelWidth = 0;
        int panelHeight = 0;

        // Piller endpoints (We are not storing in Point object since we need individual x, y-coordinate)
        int pillerVerBottomX;
        int pillerVerBootomY;
        int pillerVerTopX;
        int pillerVerTopY;
        int pillerHorRightX;
        int pillerHorRightY;
        int pillerHorLeftX;
        int pillerHorLeftY;

        // Rope data
        int ropeTopX;
        int ropeTopY;
        int ropeBottomX;
        int ropeBottomY;

        // Head Data
        int diameter = 40;
        int HeadBoundingRectX;

        // Body data
        int bodyBoundingRectY;
        int bodySize;



        public Hangman()
        {
            InitializeComponent();
            AddButtons();
        }

        private void AddButtons()
        {
            // (int) before a char like 'A' or 'Z'
            // casts the character to its integer character value
            for (int i = (int)'A'; i <= (int)'Z'; i++)
            {
                Button b = new Button
                {
                    Text = ((char)i).ToString(),
                    Parent = flowLayoutPanel1,
                    Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold),
                    Size = new Size(40, 40),
                    BackColor = Color.LawnGreen
                };
                b.Click += B_Click; // Event hook-up
            }



            // Disabling buttons
            flowLayoutPanel1.Enabled = false;
        }
        // create click event for each letter button generated by the method above
        void B_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            char charClicked = b.Text.ToCharArray()[0];
            b.Enabled = false;

            if ((CurrentWord = CurrentWord.ToUpper()).Contains(charClicked))
            {
                // char is there (right guess)
                lblInfo.Text = "Awesome!";
                lblInfo.ForeColor = Color.Green;
                char[] charArray = CurrentWord.ToCharArray();
                for (int i = 0; i < CurrentWord.Length; i++)
                {
                    if (charArray[i] == charClicked)
                        labels[i].Text = charClicked.ToString();
                }

                // Winning condition               
                if (labels.Where(x => x.Text.Equals(DefaultChar)).Any())
                    return;

                lblInfo.ForeColor = Color.Green;
                lblInfo.Text = "Hurray! You win.";
                flowLayoutPanel1.Enabled = false;
            }
            else
            {
                // Wrong guess
                lblInfo.Text = "Boo..";
                lblInfo.ForeColor = Color.Brown;




                if (CurrHangState != CurrentState.LeftLeg)
                    CurrHangState++;
                lblGuessLeft.Text = (HangStateSize - (int)CurrHangState).ToString();
                lblWrongGuesses.Text += string.IsNullOrWhiteSpace(lblWrongGuesses.Text) ? charClicked.ToString() : "," + charClicked;


                panel1.Invalidate();

                if (CurrHangState == CurrentState.LeftLeg)
                {
                    lblInfo.Text = "You lose!";
                    lblInfo.ForeColor = Color.Red;
                    flowLayoutPanel1.Enabled = false;

                    // Reveal the word
                    for (int i = 0; i < CurrentWord.Length; i++)
                    {
                        if (labels[i].Text.Equals(DefaultChar))
                        {
                            labels[i].Text = CurrentWord[i].ToString();
                            labels[i].ForeColor = Color.Blue;
                        }
                    }
                }
            }

        }

        // Initialize default variables for hangman
        private void InitializeVars()
        {
            // Global graphics data            
            p = new Pen(Color.Blue, 20);
            pRope = new Pen(Color.Blue, 5);
            PanelLocX = panel1.Location.X;
            panelLocY = panel1.Location.Y;
            panelWidth = panel1.Width;
            panelHeight = panel1.Height;

            // Piller endpoints (We are not storing in Point member since we need individual x, y-coordinate)
            pillerVerBottomX = panelWidth - 30;
            pillerVerBootomY = panelHeight - 15;
            pillerVerTopX = pillerVerBottomX;
            pillerVerTopY = panelHeight - panelHeight + 30;
            pillerHorRightX = panelWidth - 30 + 10;
            pillerHorRightY = panelHeight - panelHeight + 50;
            pillerHorLeftX = panelWidth - panelWidth + 50;
            pillerHorLeftY = pillerHorRightY;

            // Rope data
            ropeTopX = (pillerHorRightX + pillerHorLeftX) / 3;
            ropeTopY = pillerHorLeftY;
            ropeBottomX = ropeTopX;
            ropeBottomY = ropeTopY + 30; // 30 is rope length

            // Head Data
            diameter = 40;
            HeadBoundingRectX = ropeBottomX - diameter / 2;

            // Body data
            bodyBoundingRectY = ropeBottomY + diameter;
            bodySize = (pillerVerBootomY - pillerVerTopY) / 2;
        }



        private void BtnStart_Click(object sender, EventArgs e)
        {
            // check if game is currently in program by checking if the button
            // panel is enabled
            if (flowLayoutPanel1.Enabled)
            {
                //as if user wants to start a new game using an if statement and a message box
                if (MessageBox.Show("Game is currently in process, would you like to start gain?", "Game in progress", MessageBoxButtons.OKCancel) ==
                    System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }
            // if the user wants to start a new game
            // reset controls
            // select a new word
            // add labels for each letter of chosen word
            ResetControls();
            SelectWord();
            AddLabels();
        }

        // create method to add labels for each letter to group box that will contain the labels
        private void AddLabels()
        {
            // Add word to labels and labels to group box
            groupBoxWord.Controls.Clear();
            labels.Clear();
            // convert selected word to an array of characters
            char[] wordChars = CurrentWord.ToCharArray();
            // get length of word
            int len = wordChars.Length;
            int refer = groupBoxWord.Width / len;
            // for each index of the length of the array add a label
            for (int i = 0; i < len; i++)
            {
                Label l = new Label
                {
                    Text = DefaultChar, // the default char is "__"
                    Location = new Point(10 + i * refer, groupBoxWord.Height - 30),
                    // set the parent of the labels which is groupBoxWord
                    Parent = groupBoxWord
                };
                // bring the labels to the front of the group box so they can be seen
                l.BringToFront();
                // add labels to groupbox
                labels.Add(l);
            }

            // update the lbl for the length of the word and how many guesses the user has left to initial state.
            lblLength.Text = len.ToString();
            lblGuessLeft.Text = HangStateSize.ToString();
        }
        // method for resetting controls when the user starts a new game
        private void ResetControls()
        {
            // reset form
            // clear the button panel
            flowLayoutPanel1.Controls.Clear();
            // add buttons for letters
            AddButtons();
            // set the initial state of the game in the imageBox
            CurrHangState = CurrentState.None;
            panel1.BackgroundImage = null;
            // set the label holding the characters that were wrong guesses to an empty string
            lblWrongGuesses.Text = "";
            // set info lbl to an empty string
            lblInfo.Text = "";
            // enable the buttonPanel
            flowLayoutPanel1.Enabled = true;

        }
        // following method Randomizes a word from reading the text file (word.txt) from the Resources folder of the project
        private void SelectWord()
        {
            Random random = new Random();
            CurrentWord = words[random.Next(0, words.Length - 1)];

            //Random r = new Random();
            //var allWords = reader.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            //currentWord = allWords[r.Next(0, allWords.Length - 1)];

        }




        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            InitializeVars();
            var g = e.Graphics; //Graphic to draw on


            if (CurrHangState >= CurrentState.Piller)
            {
                g.DrawLine(p, new Point(pillerVerBottomX, pillerVerBootomY), new Point(pillerVerTopX, pillerVerTopY));
                g.DrawLine(p, new Point(pillerHorRightX, pillerHorRightY), new Point(pillerHorLeftX, pillerHorLeftY));
            }

            if (CurrHangState >= CurrentState.Rope)
            {
                g.DrawLine(pRope, new Point(ropeTopX, ropeTopY), new Point(ropeBottomX, ropeBottomY));
            }

            if (CurrHangState >= CurrentState.Head)
            {
                g.DrawEllipse(pRope, new Rectangle(new Point(HeadBoundingRectX, ropeBottomY), new Size(diameter, diameter)));
                g.FillRectangles(new SolidBrush(Color.Crimson),
                    new[] {
                            new Rectangle( new Point(HeadBoundingRectX + 10, ropeBottomY + 10), new Size(6, 6)), // Left eye
                            new Rectangle( new Point(HeadBoundingRectX + diameter - 10 - 6, ropeBottomY + 10), new Size(6, 6)), // Right eye
                            new Rectangle(new Point(ropeBottomX - 5/2, ropeBottomY + diameter/2), new Size(5, 5)),  // Nose
                            new Rectangle(new Point(ropeBottomX - 10, ropeBottomY + diameter/2 + 10), new Size(20, 5))   // Mouth
                        });
            }

            if (CurrHangState >= CurrentState.Body)
            {
                g.DrawEllipse(pRope, new Rectangle(new Point(HeadBoundingRectX, bodyBoundingRectY), new Size(diameter, bodySize)));
            }

            if (CurrHangState >= CurrentState.LeftArm)
            {
                g.DrawCurve(pRope,
                new[] {
                            new Point(HeadBoundingRectX + 8, bodyBoundingRectY + 15),
                            new Point(HeadBoundingRectX - 30, bodyBoundingRectY + 30),
                            new Point(HeadBoundingRectX - 30, bodyBoundingRectY + 20),

                            new Point(HeadBoundingRectX + 5, bodyBoundingRectY + 25)
                        });
            }

            if (CurrHangState >= CurrentState.RightArm)
            {
                g.DrawCurve(pRope,
                 new[] {
                            new Point(HeadBoundingRectX + diameter - 8, bodyBoundingRectY + 15),
                            new Point(HeadBoundingRectX + diameter + 30, bodyBoundingRectY + 30),
                            new Point(HeadBoundingRectX + diameter + 30, bodyBoundingRectY + 20),

                            new Point(HeadBoundingRectX + diameter - 5, bodyBoundingRectY + 25)
                        });
            }

            if (CurrHangState >= CurrentState.RightLeg)
            {
                g.DrawCurve(pRope,
                  new[] {
                            new Point(HeadBoundingRectX + diameter - 8, bodyBoundingRectY + bodySize - 15),
                            new Point(HeadBoundingRectX + diameter + 30, bodyBoundingRectY + bodySize - 5),
                            new Point(HeadBoundingRectX + diameter + 30, bodyBoundingRectY + bodySize),
                            new Point(HeadBoundingRectX + diameter - 5, bodyBoundingRectY + bodySize - 25)
                        });
            }

            if (CurrHangState >= CurrentState.LeftLeg)
            {
                g.DrawCurve(pRope,
                new[] {
                            new Point(HeadBoundingRectX + 8, bodyBoundingRectY + bodySize - 15),
                            new Point(HeadBoundingRectX - 30, bodyBoundingRectY + bodySize - 5),
                            new Point(HeadBoundingRectX - 30, bodyBoundingRectY + bodySize),
                            new Point(HeadBoundingRectX + 5, bodyBoundingRectY + bodySize - 25)
                        });
            }


        }



        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {



        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Hangman hangman &&
                   panelLocY == hangman.panelLocY;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object InitializeLifetimeService()
        {
            return base.InitializeLifetimeService();
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return base.CreateObjRef(requestedType);
        }

        protected override object GetService(Type service)
        {
            return base.GetService(service);
        }

        protected override AccessibleObject GetAccessibilityObjectById(int objectId)
        {
            return base.GetAccessibilityObjectById(objectId);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            return base.GetPreferredSize(proposedSize);
        }

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return base.CreateAccessibilityInstance();
        }

        protected override void DestroyHandle()
        {
            base.DestroyHandle();
        }

        protected override void InitLayout()
        {
            base.InitLayout();
        }

        protected override bool IsInputChar(char charCode)
        {
            return base.IsInputChar(charCode);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            return base.IsInputKey(keyData);
        }

        protected override void NotifyInvalidate(Rectangle invalidatedArea)
        {
            base.NotifyInvalidate(invalidatedArea);
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
        }

        protected override void OnCausesValidationChanged(EventArgs e)
        {
            base.OnCausesValidationChanged(e);
        }

        protected override void OnContextMenuChanged(EventArgs e)
        {
            base.OnContextMenuChanged(e);
        }

        protected override void OnContextMenuStripChanged(EventArgs e)
        {
            base.OnContextMenuStripChanged(e);
        }

        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
        }

        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
        }

        protected override void OnNotifyMessage(Message m)
        {
            base.OnNotifyMessage(m);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
        }

        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            base.OnParentBackgroundImageChanged(e);
        }

        protected override void OnParentBindingContextChanged(EventArgs e)
        {
            base.OnParentBindingContextChanged(e);
        }

        protected override void OnParentCursorChanged(EventArgs e)
        {
            base.OnParentCursorChanged(e);
        }

        protected override void OnParentEnabledChanged(EventArgs e)
        {
            base.OnParentEnabledChanged(e);
        }

        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
        }

        protected override void OnParentForeColorChanged(EventArgs e)
        {
            base.OnParentForeColorChanged(e);
        }

        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            base.OnParentRightToLeftChanged(e);
        }

        protected override void OnParentVisibleChanged(EventArgs e)
        {
            base.OnParentVisibleChanged(e);
        }

        protected override void OnPrint(PaintEventArgs e)
        {
            base.OnPrint(e);
        }

        protected override void OnTabIndexChanged(EventArgs e)
        {
            base.OnTabIndexChanged(e);
        }

        protected override void OnTabStopChanged(EventArgs e)
        {
            base.OnTabStopChanged(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }

        protected override void OnHelpRequested(HelpEventArgs hevent)
        {
            base.OnHelpRequested(hevent);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }

        protected override void OnMarginChanged(EventArgs e)
        {
            base.OnMarginChanged(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        protected override void OnDpiChangedBeforeParent(EventArgs e)
        {
            base.OnDpiChangedBeforeParent(e);
        }

        protected override void OnDpiChangedAfterParent(EventArgs e)
        {
            base.OnDpiChangedAfterParent(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
        }

        protected override void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
        {
            base.OnQueryContinueDrag(qcdevent);
        }

        protected override void OnRegionChanged(EventArgs e)
        {
            base.OnRegionChanged(e);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnChangeUICues(UICuesEventArgs e)
        {
            base.OnChangeUICues(e);
        }

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

        protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew)
        {
            base.RescaleConstantsForDpi(deviceDpiOld, deviceDpiNew);
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            return base.PreProcessMessage(ref msg);
        }

        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            return base.ProcessKeyEventArgs(ref m);
        }

        protected override bool ProcessKeyMessage(ref Message m)
        {
            return base.ProcessKeyMessage(ref m);
        }

        public override void ResetBackColor()
        {
            base.ResetBackColor();
        }

        public override void ResetCursor()
        {
            base.ResetCursor();
        }

        public override void ResetFont()
        {
            base.ResetFont();
        }

        public override void ResetForeColor()
        {
            base.ResetForeColor();
        }

        public override void ResetRightToLeft()
        {
            base.ResetRightToLeft();
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        public override void ResetText()
        {
            base.ResetText();
        }

        protected override Size SizeFromClientSize(Size clientSize)
        {
            return base.SizeFromClientSize(clientSize);
        }

        protected override void OnImeModeChanged(EventArgs e)
        {
            base.OnImeModeChanged(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
        }

        protected override Point ScrollToControl(Control activeControl)
        {
            return base.ScrollToControl(activeControl);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
        }

        protected override void OnAutoValidateChanged(EventArgs e)
        {
            base.OnAutoValidateChanged(e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        protected override void AdjustFormScrollbars(bool displayScrollbars)
        {
            base.AdjustFormScrollbars(displayScrollbars);
        }

        protected override Control.ControlCollection CreateControlsInstance()
        {
            return base.CreateControlsInstance();
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
        }

        protected override void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);
        }

        protected override bool ProcessMnemonic(char charCode)
        {
            return base.ProcessMnemonic(charCode);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }

        protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            base.OnBackgroundImageLayoutChanged(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        protected override void OnHelpButtonClicked(CancelEventArgs e)
        {
            base.OnHelpButtonClicked(e);
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnMaximizedBoundsChanged(EventArgs e)
        {
            base.OnMaximizedBoundsChanged(e);
        }

        protected override void OnMaximumSizeChanged(EventArgs e)
        {
            base.OnMaximumSizeChanged(e);
        }

        protected override void OnMinimumSizeChanged(EventArgs e)
        {
            base.OnMinimumSizeChanged(e);
        }

        protected override void OnInputLanguageChanged(InputLanguageChangedEventArgs e)
        {
            base.OnInputLanguageChanged(e);
        }

        protected override void OnInputLanguageChanging(InputLanguageChangingEventArgs e)
        {
            base.OnInputLanguageChanging(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
        }

        protected override void OnMdiChildActivate(EventArgs e)
        {
            base.OnMdiChildActivate(e);
        }

        protected override void OnMenuStart(EventArgs e)
        {
            base.OnMenuStart(e);
        }

        protected override void OnMenuComplete(EventArgs e)
        {
            base.OnMenuComplete(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
        }

        protected override bool OnGetDpiScaledSize(int deviceDpiOld, int deviceDpiNew, ref Size desiredSize)
        {
            return base.OnGetDpiScaledSize(deviceDpiOld, deviceDpiNew, ref desiredSize);
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            base.OnRightToLeftLayoutChanged(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessDialogChar(char charCode)
        {
            return base.ProcessDialogChar(charCode);
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessTabKey(bool forward)
        {
            return base.ProcessTabKey(forward);
        }

        protected override void Select(bool directed, bool forward)
        {
            base.Select(directed, forward);
        }

        protected override void ScaleCore(float x, float y)
        {
            base.ScaleCore(x, y);
        }

        protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
        {
            return base.GetScaledBounds(bounds, factor, specified);
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            base.SetClientSizeCore(x, y);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void UpdateDefaultButton()
        {
            base.UpdateDefaultButton();
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
        }

        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);
        }

        public override bool ValidateChildren()
        {
            return base.ValidateChildren();
        }

        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            return base.ValidateChildren(validationConstraints);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        private void LblInfo_Click(object sender, EventArgs e)
        { } 
        public Bitmap[] HangImages { get; } = { HangmanProj.Properties.Resources.Art1, HangmanProj.Properties.Resources.Art2, HangmanProj.Properties.Resources.Art3,
            HangmanProj.Properties.Resources.Art4, HangmanProj.Properties.Resources.Art5, HangmanProj.Properties.Resources.Art6,
            HangmanProj.Properties.Resources.Art7, HangmanProj.Properties.Resources.none };
         }
       
    }

    


    
            

       
