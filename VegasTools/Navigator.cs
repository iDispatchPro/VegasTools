using System;
using System.IO;
using System.Windows.Forms;
using ScriptPortal.Vegas;

namespace VegasTools
{
    public partial class Navigator : UserControl
    {
        public Navigator(Vegas AVegas)
        {
            vegas = AVegas;

            #region Events

            vegas.ProjectOpened += delegate(object sender, EventArgs e)
            {
                UpdateMarkers();
                UpdateRegions();
                UpdateVideoEvents();
            };

            vegas.MarkersChanged += delegate(object sender, EventArgs e)
            {
                UpdateMarkers();
                UpdateRegions();
            };

            vegas.TrackEventCountChanged += delegate(object sender, EventArgs e)
            {
                UpdateVideoEvents();
                UpdateAudioEvents();
            };

            vegas.TrackEventTimeChanged += delegate(object sender, EventArgs e)
            {
                UpdateVideoEvents();
                UpdateAudioEvents();
            };

            vegas.TrackEventStateChanged += delegate(object sender, EventArgs e)
            {
                UpdateVideoEvents();
                UpdateAudioEvents();
            };

            vegas.TrackStateChanged += delegate(object sender, EventArgs e)
            {
                UpdateVideoEvents();
                UpdateAudioEvents();
            };

            vegas.MediaPoolChanged += delegate(object sender, EventArgs e)
            {
                UpdateVideoEvents();
                UpdateAudioEvents();
            };

            #endregion

            InitializeComponent();
        }

        void UpdateVideoEvents()
        {
            VideoEvents_View.BeginUpdate();

            try
            {
                VideoEvents_View.Items.Clear();

                String Filter = VideoEvents_Filter.Text.ToUpper();

                foreach (Track T in vegas.Project.Tracks)
                {
                    foreach (ScriptPortal.Vegas.TrackEvent E in T.Events)
                    {
                        VideoEvent V = E as VideoEvent;

                        if (
                            (V != null) &&
                            (V.ActiveTake != null) &&
                            (V.ActiveTake.Name.ToUpper().Contains(Filter) || V.ActiveTake.MediaPath.ToUpper().Contains(Filter))
                           )
                        {
                            String FXs = "";

                            foreach (Effect FX in V.Effects)
                                FXs += (FX.PlugIn.Name + "; ");

                            if (FXs.ToUpper().Contains(VideoEvents_Filter_FX.Text.ToUpper()))
                            {
                                ListViewItem item = VideoEvents_View.Items.Add(V.Index.ToString());

                                ScriptPortal.Vegas.VideoStream VS = (V.ActiveTake.MediaStream as ScriptPortal.Vegas.VideoStream);
                                item.SubItems.Add(V.ActiveTake.Name);
                                item.SubItems.Add(V.Start.ToPositionString());
                                item.SubItems.Add(V.Length.ToPositionString());
                                item.SubItems.Add(VS.FieldOrder.ToString());

                                if (!V.ActiveTake.MediaPath.Contains(".") || File.Exists(V.ActiveTake.MediaPath))
                                {
                                    item.ImageIndex = 0;
                                    item.SubItems.Add(VS.Width.ToString() + " x " + VS.Height.ToString());
                                    item.SubItems.Add(VS.PixelAspectRatio.ToString());
                                    item.SubItems.Add(VS.AlphaChannel.ToString());
                                }
                                else
                                {
                                    item.ImageIndex = 4;
                                    item.SubItems.Add("N/A");
                                    item.SubItems.Add("N/A");
                                    item.SubItems.Add("N/A");
                                }

                                item.SubItems.Add(V.ActiveTake.MediaPath);
                                item.SubItems.Add(FXs);

                                item.Tag = V;
                            }
                        }
                    }
                }
            }
            finally
            {
                VideoEvents_View.EndUpdate();
            }
        }

        void UpdateAudioEvents()
        {
            AudioEvents_View.BeginUpdate();

            try
            {
                AudioEvents_View.Items.Clear();

                String Filter = VideoEvents_Filter.Text.ToUpper();

                foreach (Track T in vegas.Project.Tracks)
                {
                    foreach (ScriptPortal.Vegas.TrackEvent E in T.Events)
                    {
                        AudioEvent A = E as AudioEvent;

                        if (
                            (A != null) &&
                            (A.ActiveTake != null) &&
                            (A.ActiveTake.Name.ToUpper().Contains(Filter) || A.ActiveTake.MediaPath.ToUpper().Contains(Filter))
                           )
                        {
                            ListViewItem item = AudioEvents_View.Items.Add(A.Index.ToString());

                            ScriptPortal.Vegas.AudioStream AS = (A.ActiveTake.MediaStream as ScriptPortal.Vegas.AudioStream);

                            item.SubItems.Add(A.ActiveTake.Name);
                            item.SubItems.Add(A.Start.ToPositionString());
                            item.SubItems.Add(A.Length.ToPositionString());

                            if (File.Exists(A.ActiveTake.MediaPath))
                            {
                                item.ImageIndex = 1;
                                item.SubItems.Add(AS.Channels.ToString());
                                item.SubItems.Add(AS.SampleRate.ToString());
                                item.SubItems.Add(AS.BitDepth.ToString());
                            }
                            else
                            {
                                item.ImageIndex = 4;
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                                item.SubItems.Add("");
                            }

                            item.SubItems.Add(A.ActiveTake.MediaPath);

                            item.Tag = A;
                        }
                    }
                }
            }
            finally
            {
                AudioEvents_View.EndUpdate();
            }
        }

        void UpdateRegions()
        {
            Regions_View.BeginUpdate();

            try
            {
                Regions_View.Items.Clear();

                String Filter = Regions_Filter.Text.ToUpper();

                foreach (ScriptPortal.Vegas.Region R in vegas.Project.Regions)
                {
                    String Label = R.Label.ToUpper();

                    if (((Label != "") || (Regions_ShowUnLabelled.Checked)) && (Label.Contains(Filter)))
                    {
                        ListViewItem item = Regions_View.Items.Add(R.Index.ToString());
                        item.SubItems.Add(R.Label);
                        item.SubItems.Add(R.Position.ToPositionString());
                        item.SubItems.Add(R.Length.ToPositionString());
                        item.Tag = R;
                        item.ImageIndex = 3;
                    }
                }
            }
            finally
            {
                Regions_View.EndUpdate();
            }
        }

        void UpdateMarkers()
        {
            Markers_View.BeginUpdate();

            try
            {
                Markers_View.Items.Clear();

                String Filter = Markers_Filter.Text.ToUpper();

                foreach (Marker M in vegas.Project.Markers)
                {
                    String Label = M.Label.ToUpper();

                    if (((Label != "") || (Markers_ShowUnLabelled.Checked)) && (Label.Contains(Filter)))
                    {
                        ListViewItem item = Markers_View.Items.Add(M.Index.ToString());
                        item.SubItems.Add(M.Label);
                        item.SubItems.Add(M.Position.ToPositionString());
                        item.Tag = M;
                        item.ImageIndex = 2;
                    }
                }
                /*
                if (focusedItem != null)
                    foreach (ListViewItem li in list.Items)
                        if (li.Tag == focusedItem)
                            list.FocusedItem = li;*/
            }
            finally
            {
                Markers_View.EndUpdate();
            }
        }

        void ShowItem(object AItem)
        {
            if (AItem is Marker)
                vegas.Cursor = (AItem as Marker).Position;
        }

        Vegas vegas;

        void ActivateMarker()
        {
            if (Markers_View.FocusedItem != null)
                ShowItem(Markers_View.FocusedItem.Tag);
        }

        private void Markers_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Markers_Autonavigate.Checked)
                ActivateMarker();
        }

        private void Markers_ShowUnLabelled_Click(object sender, EventArgs e)
        {
            UpdateMarkers();
        }

        private void Markers_View_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ActivateMarker();
        }

        private void Markers_View_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            (Markers_View.Items[e.Item].Tag as Marker).Label = e.Label;
        }

        private void Markers_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                using (UndoBlock undo = new UndoBlock("Delete markers"))
                {
                    foreach (ListViewItem item in Markers_View.SelectedItems)
                        vegas.Project.Markers.Remove(item.Tag as Marker);
                }
            }

            if (e.KeyData == Keys.Enter)
                ActivateMarker();
        }

        private void Markers_Filter_TextChanged(object sender, EventArgs e)
        {
            UpdateMarkers();
        }

        void ActivateRegion(bool AForseSelect)
        {
            if (Regions_View.FocusedItem != null)
            {
                ScriptPortal.Vegas.Region R = Regions_View.FocusedItem.Tag as ScriptPortal.Vegas.Region;
                ShowItem(R);

                if (AForseSelect)
                {
                    vegas.SelectionStart = R.Position;
                    vegas.SelectionLength = R.Length;
                }
            }
        }

        void ActivateVideoEvent(bool AForseSelect)
        {
            if (VideoEvents_View.FocusedItem != null)
            {
                VideoEvent E = VideoEvents_View.FocusedItem.Tag as VideoEvent;
                vegas.Cursor = E.Start;

                if (AForseSelect)
                {
                    vegas.SelectionStart = E.Start;
                    vegas.SelectionLength = E.Length;
                }
            }
        }

        private void Regions_ShowUnLabelled_Click(object sender, EventArgs e)
        {
            UpdateRegions();
        }

        private void Regions_Filter_TextChanged(object sender, EventArgs e)
        {
            UpdateRegions();
        }

        private void Regions_View_DoubleClick(object sender, EventArgs e)
        {
            ActivateRegion(true);
        }

        private void Regions_View_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (Regions_Autonavigate.Checked)
                ActivateRegion(false);
        }

        private void VideoEvents_View_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //if (VideoEvent_Autonavigate.Checked)
                ActivateVideoEvent(false);
        }

        private void VideoEvents_View_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ActivateVideoEvent(true);
        }

        private void VideoEvents_Filter_TextChanged(object sender, EventArgs e)
        {
            UpdateVideoEvents();
        }

        private void VideoEvents_Filter_FX_TextChanged(object sender, EventArgs e)
        {
            UpdateVideoEvents();
        }
    }
}
