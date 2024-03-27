﻿namespace GIT.States
{
    internal class Draftstate : State
    {
        public Draftstate(FileSystem file) : base(file)
        {

        }
        #region function
        public override void Commit()
        {
            file.ChangeState(new CommitState(file)) ;
            Console.WriteLine($"the file - {file.Name} pass to commit state");
        }

        public override void Darft()
        {
            throw new InvalidStateException("You are in the desired state ");
        }

        public override void ErorState()
        {
            file.ChangeState(new ErorStates(file));
        }

        public override void GetMessage()
        {
            throw new NotImplementedException();
        }

        public override void Staged()
        {
            throw new InvalidStateException("No permission to switch to Staged state");
        }

        public override void underReview()
        {
            throw new InvalidStateException("No permission to switch to underReview state");
        }
        #endregion
    }
}
