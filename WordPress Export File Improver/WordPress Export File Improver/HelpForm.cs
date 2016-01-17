﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordPress_Duplicate_Resolver
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
		}

		private void HelpForm_Load(object sender, EventArgs e)
		{
			this.Icon = SystemIcons.Information;
			listBoxTopics.Items.Add(new DisplayItem
			{
				DisplayMember = "Welcome",
				ValueMember = @"Welcome to WordPress Export File Improver.

This application takes XML files generated by the WordPress exporter and makes a variety of changes that will make the import process more successful.

Choose a topic on the left to learn more."
			});
			listBoxTopics.Items.Add(new DisplayItem
			{
				DisplayMember = "Duplicates",
				ValueMember = @"Your WordPress installation may have allowed you to create posts and media with the same title. However, when trying to import these posts, you will find that the importer will reject these duplicates.

This behaviour is intended to be helpful, as if you are restarting an unfinished import, you do not want duplicates. However, it also means you cannot import multiple posts and media files with the same title.

To solve this problem, use this program to automatically rename your duplicates. This program will add the desired extension to each duplicate it identifies, making sure the WordPress importer allows them through while still offering you the ability to restart your import part way through.

Since the program keeps track of the number of times a particular title has appeared across multiple files, please select all your export files to process at once, so that you can ensure all duplicates have unique names."
			});
			listBoxTopics.Items.Add(new DisplayItem
			{
				DisplayMember = "Media Dates",
				ValueMember = @"This option is for if your images are stored in the yourblog.com/year/month/day/image_name or yourblog.com/year/month/image_name format.

By default, WordPress will store your media files in folders on the server corresponding to the date that they were uploaded to the server. However, when importing images, it will use the 'Published Date'.

It is unclear what this published date corresponds to, however this mismatch is common enough that you may find images on posts 404-ing after import. If this is the case, or if you would like to avoid this happening in the first place, use the 'Change published dates to upload dates to preserve file structure' option to fix it. 

The program will extract the date from the image URL and then change the published date to match. 

As time information is not included, all published dates will be reset to midnight on the upload date. If a day number is not available, it will be set to the first of the upload month."
			});
			listBoxTopics.Items.Add(new DisplayItem
			{
				DisplayMember = "Additional Notes",
				ValueMember = @"This application was developed as I was facing these problems when importing a WordPress blog. Some of the other tools that I found invaluable during this process included:

RangerPretzel's WXR File Splitter: 
http://www.rangerpretzel.com/content/view/20/1/
(for splitting export files larger than the server can handle)

Better Search Replace plugin: 
https://wordpress.org/plugins/better-search-replace/
(for replacing image URLs referenced in posts)"
			});
			//End topics
			listBoxTopics.DisplayMember = "DisplayMember";
			listBoxTopics.ValueMember = "ValueMember";
			listBoxTopics.SelectedIndex = 0;
		}

		private void listBoxTopics_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBoxHelpText.Text = ((DisplayItem)listBoxTopics.SelectedItem).ValueMember.ToString();
		}
	}
}
