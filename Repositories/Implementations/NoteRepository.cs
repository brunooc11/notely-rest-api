namespace NotelyRestApi.Repositories.Implementations
{
    using Models;
    using System.Collections.Generic;
    using Database;
    public class NoteRepository : INoteRepository
    {
        private NotelyDbContext _context;

        public NoteRepository(NotelyDbContext context)
        {
            _context = context;
        }

        public Note FindNoteById(long id)
        {
            var note = _context.Notes.Find((int)id);
            return note;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            var notes = _context.Notes;
            return notes;
            // este metodo devolve todas as notas (Note) da base de dados. é uma forma de devolver uma lista de objetos que podem ser percorridos com um foreach, por exemplo.
        }

        public void SaveNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void EditNote(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void DeleteNote(Note noteModel)
        {
            _context.Notes.Remove(noteModel);
            _context.SaveChanges();
        }
    }
}
