namespace Ecommerce.Business.Interfaces
{
    public interface IImageService
    {
        bool UploadImage(string image, string imageName);
    }
}