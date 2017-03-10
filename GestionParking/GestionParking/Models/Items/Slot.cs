﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parking
{
    public class Slot
    {
        private int m_id;
        private Coord m_location;
        private DateTime m_lastTimeReserved;
        private DateTime m_lastTimeTaken;
        private SlotState m_state;
        //private PictureBox m_pict;

        public Slot(int p_id, int p_CoordX, int p_CoordY, DateTime p_lastTimeReserved, DateTime p_lastTimeTaken, String p_state)
        {
            this.m_id = p_id;
            this.m_location = new Coord(p_CoordX, p_CoordY);


            
            if(p_lastTimeReserved != null)
            {
                this.m_lastTimeReserved = p_lastTimeReserved;
            }
            else
            {
                new DateTime(0);
            }
            
            if(p_lastTimeTaken != null)
            {
                this.m_lastTimeTaken = p_lastTimeTaken;
            }
            else
            {
                this.m_lastTimeTaken = new DateTime(0);
            }
            

            if(p_state == "Empty")
            {
                this.m_state = SlotState.Empty;
            }
            else if(p_state == "Used")
            {
                this.m_state = SlotState.Used;
            }
            else
            {
                this.m_state = SlotState.Reserved;
            }

            /*PictureBox tempPict = new PictureBox();
            tempPict.BackColor = Color.Green;
            tempPict.Location = new Point(this.m_location.x, this.m_location.y);
            tempPict.Tag = p_id;
            
            //tempPict.Click += GestionParking.Parking.Picture_Click; //Ajout de l'evenement au clic
            this.m_pict = tempPict;*/

        }
        

        public Slot(int p_id, Coord p_coord)
        {
            this.m_id = p_id;
            this.m_location = p_coord;
            this.m_lastTimeReserved = new DateTime(0);
            this.m_lastTimeTaken = new DateTime(0);
            this.m_state = SlotState.Empty;

            /*PictureBox tempPict = new PictureBox();
            tempPict.BackColor = Color.Green;
            tempPict.Location = new Point(this.m_location.x, this.m_location.y);
            tempPict.Tag = p_id;
            this.m_pict = tempPict;
            this.pict.Click += GestionParking.Parking.Picture_Click; //Ajout de l'evenement au clic*/
        }

        public int ID
        {
            get
            {
                return m_id;
            }

            private set
            {
                m_id = value;
            }
        }

        public SlotState state
        {
            get
            {
                return m_state;
            }
            private set
            {
                m_state = value;
            }
        }

        public DateTime lastTimeTaken
        {
            get
            {
                return m_lastTimeTaken;
            }

            private set
            {
                m_lastTimeTaken = value;
            }
        }

        public DateTime lastTimeReserved
        {
            get
            {
                return m_lastTimeReserved;
            }

            private set
            {
                m_lastTimeReserved = value;
            }
        }

        public Coord location
        {
            get
            {
                return m_location;
            }

            private set
            {
                m_location = value;
            }
        }

        /*public PictureBox pict
        {
            get
            {
                return m_pict;
            }

            set
            {
                m_pict = value;
            }
        }*/

        public void NewState(SlotState p_s)
        {
            switch (p_s)
            {
                case SlotState.Empty:
                    if (this.m_state == SlotState.Empty)
                        throw new Exception("Allready empty") ;
                        ;
                    break;
                case SlotState.Reserved:
                    if (this.m_state == SlotState.Reserved)
                        throw new Exception("Allready Reserved");
                    ;
                    m_lastTimeTaken = DateTime.Now;
                    break;
                case SlotState.Used:
                    if (this.m_state == SlotState.Used)
                        throw new Exception("Allready Used");
                    ;
                    m_lastTimeTaken = DateTime.Now;
                    break;
            }

            this.m_state = p_s;
        }
    }
}