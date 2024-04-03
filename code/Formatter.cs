﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WMPio
{
    class Formatter
    {
        private const string c_vertex = @"VERTEX	{0:F3} {1:F3} {2:F3};#{3:D}";
        private const string c_region = @"REGION	{0} {1:F3} {2:F3};#{3:D}";
        private const string c_wall = @"WALL	{0} {1:D} {2:D}	{3:D}	{4:D}	{5:F3} {6:F3};#{7:D}";
        private const string c_player = @"PLAYER_START	{0:F3} {1:F3} {2:F3}	{3:D};#{4:D}";
        private const string c_thing = @"THING	{0} {1:F3} {2:F3} {3:F3}	{4:D};#{5:D}";
        private const string c_actor = @"ACTOR	{0} {1:F3} {2:F3} {3:F3}	{4:D};#{5:D}";
        private const string c_way = @"WAY	{0}	{1};#{2:D}";

        private const string c_header = @"#  This file ""{0}"" was generated by WMPio v{1}
#  WMP Exporter for 3D GameStudio by firoball
#  creation date: {2:dd.MM.yyyy}    time: {2:HH:mm:ss}";

        private const string c_spacer = @"


";

        private const string c_vertexInfo = @"#vertex	xpos ypos zpos index
#-------------------------------";

        private const string c_regionInfo = @"#region	name	floor_hgt	ceil_hgt
#---------------------------------";

        private const string c_wallInfo = @"#
#wall	name vertex vertex	region region	offsx offsy	index
#------------------------------------------------------------";
        private const string c_objectInfo = @"#player_start
#thing
#actor name xpos ypos angle region index
#---------------------------------------";

        private const string c_wayInfo = @"#way name  xpos ypos  xpos ypos  xpos ypos ...
#---------------------------------------------";

        private const string c_footer = @"#-------------------- end ------------------------";

        public static string Format(Map m, string filename)
        {
            StringBuilder wmp = new StringBuilder();

            wmp.AppendLine(string.Format(CultureInfo.InvariantCulture, c_header, filename, Assembly.GetExecutingAssembly().GetName().Version, DateTime.Now));

            wmp.AppendLine(c_spacer);
            wmp.AppendLine(c_vertexInfo);
            foreach (Vertex v in m.Vertices)
                wmp.AppendLine(v.Format(c_vertex));

            wmp.AppendLine(c_spacer);
            wmp.AppendLine(c_regionInfo);
            foreach (Region r in m.Regions)
                wmp.AppendLine(r.Format(c_region));

            wmp.AppendLine(c_spacer);
            wmp.AppendLine(c_wallInfo);
            foreach (Wall w in m.Walls)
                wmp.AppendLine(w.Format(c_wall));

            wmp.AppendLine(c_spacer);
            wmp.AppendLine(c_objectInfo);
            int cntAll = m.PlayerStarts.Count + m.Things.Count + m.Actors.Count;
            int cntP = 0;
            int cntT = 0;
            int cntA = 0;
            for (int cnt = 0; cnt < cntAll; cnt++)
            {
                //keep order by index - might be important for original WED and engine
                int idxP = (cntP < m.PlayerStarts.Count) ? m.PlayerStarts[cntP].Index : int.MaxValue;
                int idxT = (cntT < m.Things.Count) ? m.Things[cntT].Index : int.MaxValue;
                int idxA = (cntA < m.Actors.Count) ? m.Actors[cntA].Index : int.MaxValue;
                if (idxP < idxT && idxP < idxA)
                {
                    wmp.AppendLine(m.PlayerStarts[cntP].Format(c_player));
                    cntP++;
                }
                else if (idxT < idxP && idxT < idxA)
                {
                    wmp.AppendLine(m.Things[cntT].Format(c_thing));
                    cntT++;
                }
                else
                {
                    wmp.AppendLine(m.Actors[cntA].Format(c_actor));
                    cntA++;
                }
            }

            wmp.AppendLine(c_spacer);
            wmp.AppendLine(c_wayInfo);
            foreach (Way y in m.Ways)
                wmp.AppendLine(y.Format(c_way));

            wmp.AppendLine(c_spacer);
            wmp.AppendLine(c_footer);

            return wmp.ToString();
        }
    }
}
