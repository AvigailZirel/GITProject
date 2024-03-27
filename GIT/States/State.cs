﻿namespace GIT.States
{
    internal abstract class State
    {
        #region propertys
        protected FileSystem file { get; private set; }
        public State(FileSystem file) {
            this.file = file;
        }
        #endregion

        #region function
        public abstract void GetMessage();
        public abstract void ErorState();
        public abstract void Commit();
        public abstract void underReview();
        public abstract void Staged();
        public abstract void Darft();


        #endregion

    }
}
