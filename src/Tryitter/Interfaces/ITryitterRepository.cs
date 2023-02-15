using Tryitter.Models;

namespace Tryitter.Interfaces;

public interface ITryitterRepository
{
  Task<List<Student>>? GetStudentsAsync();

  Task<Student?> GetStudentAsync(int id);

  int CreateStudent(Student student);

  bool UpdateStudent(int id, Student student);

  Task<bool> DeleteStudentAsync(int id);

  Task<List<Post>>? GetAllPostsAsync(int id);

  Task<Post?> GetPostByIdAsync(int id);

  Task<Post?> GetLastPostAsync(int id);

  int CreatePost(Post post);

  bool UpdatePost(int postId, Post newPost);

  Task<bool> DeletePostAsync(int postId);
}
