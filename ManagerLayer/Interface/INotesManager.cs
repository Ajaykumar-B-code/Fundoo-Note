﻿using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface INotesManager
    {

        public NotesEntity NotesCeation(NotesCreatioinModel model, int id);

        public List<NotesEntity> GetNotes(int id);

        public NotesEntity UpdateNotes(int userId, NotesCreatioinModel model, int NotesId);
        public NotesEntity Istrash(int userId, int notesId);
        public NotesEntity Delete(int userId, int NotesId);
        public NotesEntity Addcolor(string colour, int NotesId);
        public NotesEntity isArchieve(int userId, int notesId);
        public NotesEntity isPin(int userId, int notesId);
        public NotesEntity AddRemander(int notesId, DateTime dateTime);
    }
}
