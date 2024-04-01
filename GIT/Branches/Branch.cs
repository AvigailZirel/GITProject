﻿namespace GIT.Branches
{
    internal class Branch : ICloneable, IGitItem
    {
        #region propertys
        public string Name { get; set; }
        public List<string> commit { get; set; }
        public DateTime ManufacturingDate { get; set; }
        BranchShared branch;
        public Repository repository;
        public Branch(string name)
        {
            Name = name;
            ManufacturingDate= DateTime.Now;
            branch =repository.GetEllipseDesign(Name);
            commit = new List<string>();
        }
        public Branch() { } 


        #endregion

        #region function
        public object Clone()
        {
            Branch newBranch = new Branch();
            newBranch.Name = this.Name;
            newBranch.ManufacturingDate = DateTime.Now;
            newBranch.repository = this.repository;
            newBranch.branch=repository.GetEllipseDesign(Name);
            return newBranch;

        }
        public bool Delete(Repository repository)
        {
            Console.WriteLine("you soure that you want to delete this branch");
            string c = Console.ReadLine();
            if (c.Equals("yes"))
            {
                repository.Branches.Remove(this);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Merge(IGitItem item, Repository project)
        {
            if(item.GetType() == typeof(Branch)) 
            {

                // עבור כל קובץ שנמצא באיטם
                (item as Branch).branch.filesSysyem.ForEach(f =>
                {// תבדןק אם קים קבוץ בעל אותו שם בנוכחי
                    var fs = this.branch.filesSysyem.Find(ff => ff.Name == f.Name);
                    //אם קים , תמחק אותו
                    if (fs != null)
                    // תמחק אותו
                    // 
                          this.branch.filesSysyem.Remove(fs);
                   this.branch.filesSysyem.Add(f);   
                    
                   
                });
             
               project.Branches.Remove(item as Branch );
            }
            else
            {
                this.branch.filesSysyem.Add((item as FileSystem));

            }
            Console.WriteLine("I passed from Merge");
            return true;
        }
        public void Commit()
        {

         Console.WriteLine("I pass to commite state");
        }
        public void Review()
        {
            repository.Notify();
            foreach (var file in branch.filesSysyem)
            {
               if(file.GetType()==typeof(Files))
                {
                    file.Review();
                }
                else
                {
                    (file as Folder).recorsFile();
                }
            }

        }
        public void Add(FileSystem file) 
        { 
            file.FatherBranch= this;
            this.branch.filesSysyem.Add(file);
        }

        //public Files GetFile(string name)
        //{

        //    Files res;
        //    foreach (var branch in Children)
        //    {
        //        if (branch.GetType() == typeof(Files))
        //        {
        //            if (branch.Value.Name == name)
        //            {
        //                return (Files)branch.Value;
        //            }
        //            return null;
        //        }
        //        if (branch.GetType() == typeof(Folder))
        //        {
        //            res = ((Folder)branch.Value).GetFile(name);
        //        }
        //        else res = ((Branch)branch.Value).GetFile(name);
        //        if (res != null)
        //        {
        //            return res;
        //        }
        //    }

        //    return null;
        //}

        //public Folder GetFolder(string name)
        //{
        //    Folder res = null;
        //    foreach (var branch in Children)
        //    {
        //        if (branch.GetType() == typeof(Folder))
        //        {
        //            if (branch.Value.Name == name)
        //            {
        //                return (Folder)branch.Value;
        //            }
        //            return null;
        //        }
        //        if (branch.GetType() == typeof(Branch))
        //        {
        //            res = ((Branch)branch.Value).GetFolder(name);
        //        }
        //        if (res != null)
        //        {
        //            return res;
        //        }
        //    }

        //    return null;
        //}
        #endregion
    }


}
