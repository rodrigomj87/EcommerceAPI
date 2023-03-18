using Ecommerce.Business.Interfaces;
using Ecommerce.Business.Notificacoes;

namespace Ecommerce.Business.Services
{
    public class ImageService : IImageService
    {
        private readonly INotificador _notificador;
        public ImageService(INotificador notificador) 
        {
            _notificador = notificador;
        }

        public bool UploadImage(string image, string imageName)
        {
            

            if (string.IsNullOrEmpty(image))
            {
                _notificador.Handle(new Notificacao("Forneça uma imagem para este produto!"));
                return false;                
            }
            var imageDataByteArray = Convert.FromBase64String(image);

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

            if (File.Exists(imagePath))
            {
                _notificador.Handle(new Notificacao("Já existe um arquivo com este nome!"));
                return false;
            }

            File.WriteAllBytes(imagePath, imageDataByteArray);

            return true;

        }


    }
}
