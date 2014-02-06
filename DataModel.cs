using System;
using System.Collections.Generic;

namespace TheraWii
{
    public class DataModel
    {
        private List<Therapy> therapies;
        private List<Profile> profiles;
        public bool PlayFullscreen;

        public DataModel()
        {
            therapies = new List<Therapy>();
            profiles = new List<Profile>();
            PlayFullscreen = false;
        }

        public List<Therapy> Therapies
        {
            get { return therapies; }
        }

        public List<Profile> Profiles
        {
            get { return profiles; }
        }

        public void removeTherapy(Therapy t)
        {
            therapies.Remove(t);
        }

        public void removeProfile(Profile p)
        {
            profiles.Remove(p);
        }

        public bool isProfileNameUnique(String s)
        {
            foreach (Profile p in profiles)
            {
                if (p.Name == s)
                    return false;
            }
            return true;
        }
    }

}