using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HelloWorld.Services
{
    public class Helper
    {
        public const string MovieRequestUri = "https://api.themoviedb.org/3/search/movie";
        public const string MovieAPI_Key = "12b01729e9b5d623f878c6a4e1c30fde";
        public string PhotoPath;

        private List<string> GetAllImages()
        {
            List<string> images = new List<string>
            {
                "https://media.istockphoto.com/photos/young-african-woman-smiling-at-sunset-picture-id969233490",
                "https://media.istockphoto.com/photos/beautiful-african-american-female-fitness-model-picture-id536292311",
                "https://media.istockphoto.com/photos/african-american-sports-woman-standing-against-gray-background-picture-id536721511",
                "https://media.istockphoto.com/photos/attractive-sports-woman-in-blue-sweatshirt-standing-in-nature-picture-id536686551",
                "https://media.istockphoto.com/photos/smiling-man-outdoors-in-the-city-picture-id1179420343",
                "https://media.istockphoto.com/photos/portrait-of-african-man-showing-thumbs-up-sign-picture-id1329500806",
                "https://media.istockphoto.com/photos/face-close-up-of-middle-aged-man-with-smiling-expression-picture-id1330740738",
                "https://media.istockphoto.com/photos/close-up-of-face-of-happy-creative-man-smiling-at-camera-picture-id1345718375",
                "https://media.istockphoto.com/photos/looking-directly-up-at-the-skyline-of-the-financial-district-in-picture-id1215119911",
                "https://media.istockphoto.com/photos/dubai-marina-picture-id467829216",
                "https://media.istockphoto.com/photos/panorama-sunset-colourful-sky-view-of-bangkok-cityscape-with-building-picture-id1179004056",
                "https://media.istockphoto.com/photos/bangkok-cityscape-and-chaophraya-river-picture-id496798243"
            };
            return images;
        }

        public string FetchRandomImageUrl()
        {
            int imagesCount = GetAllImages().Count();
            Random rand = new Random();
            int randomIndex = rand.Next(imagesCount);
            string imageUrl = GetAllImages()[randomIndex];
            return imageUrl;
        }
        public async Task<string> TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
                //Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
            return PhotoPath;
        }

        public async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
            }
            // save the file into local storage
            
            PhotoPath = await GetFilePath(photo);
        }

        public async Task<string> GetFilePath(FileResult file)
        {
            var newFile = Path.Combine(FileSystem.CacheDirectory, file.FileName);
            using (var stream = await file.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            return newFile;
        }
         
    }
}
