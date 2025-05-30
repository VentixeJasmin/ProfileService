using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Models;

namespace Presentation.Services;

public class ProfileService(ProfileContext context) : IProfileService
{
    private readonly ProfileContext _context = context;

    public async Task<ProfileEntity?> CreateProfile(ProfileDto dto, string? profileImage)
    {
        try
        {
            if (dto == null)
            {
                Console.WriteLine("Some required information is missing.");
                return null;
            }

            ProfileEntity profile = new()
            {
                UserId = dto.UserId,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ProfileImage = profileImage ?? ""
            };

            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return profile;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return null;
        }
    }

    public async Task<List<ProfileEntity>> GetAllProfiles()
    {
        try
        {
            var profiles = await _context.Profiles.ToListAsync();
            if (!profiles.Any())
            {
                Console.WriteLine("No venues available");
                return [];
            }

            return profiles;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return [];
        }
    }

    public async Task<ProfileEntity?> GetProfileByUserName(string userName)
    {
        try
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserName == userName);
            if (profile == null)
            {
                Console.WriteLine("Couldn't find profile.");
                return null;
            }

            return profile;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return null;
        }
    }

    public async Task<ProfileEntity?> UpdateProfile(string userName, ProfileDto updatedProfile)
    {
        try
        {
            var existingProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserName == userName);
            if (existingProfile == null)
            {
                Console.WriteLine("Couldn't find profile.");
                return null;
            }

            existingProfile.FirstName = updatedProfile.FirstName;
            existingProfile.LastName = updatedProfile.LastName;

            await _context.SaveChangesAsync();

            return existingProfile;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return null;
        }
    }

    public async Task<bool> DeleteProfile(string userName)
    {
        try
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserName == userName);
            if (profile == null)
            {
                Console.WriteLine("Couldn't find profile.");
                return false;
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return false;
        }
    }
}
