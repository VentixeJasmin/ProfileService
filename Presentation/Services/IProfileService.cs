using Presentation.Models;

namespace Presentation.Services
{
    public interface IProfileService
    {
        Task<ProfileEntity?> CreateProfile(ProfileDto dto, string? profileImage);
        Task<bool> DeleteProfile(string userName);
        Task<List<ProfileEntity>> GetAllProfiles();
        Task<ProfileEntity?> GetProfileByUserName(string userName);
        Task<ProfileEntity?> UpdateProfile(string userName, ProfileDto updatedProfile);
    }
}