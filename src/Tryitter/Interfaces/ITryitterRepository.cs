using Tryitter.Models;

namespace Tryitter.Interfaces;

public interface ITryitterRepository
{
  Task<List<Student>>? GetStudentsAsync();

  Task<Student?> GetStudentAsync(int id);

  int CreateStudent(Student student);

  bool UpdateStudent(int id, Student student);

  Task<bool> DeleteStudentAsync(int id);

  List<Post>? GetPosts(int id);

  Post? GetLastPost(int id);

  Task<int> CreatePostAsync(int id, Post post);

  Task<bool> UpdatePostAsync(int id, Post post);

  Task<bool> DeletePostAsync(int id, int postId);
}
