using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.").MinimumLength(3).WithMessage("İsim alanı minimum 3 karakterden oluşmalıdır.").MaximumLength(20).WithMessage("İsim alanı maksimum 20 karakterden oluşmalıdır.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez.").MinimumLength(3).WithMessage("Soyisim alanı minimum 3 karakterden oluşmalıdır.").MaximumLength(20).WithMessage("Soyisim alanı maksimum 20 karakterden oluşmalıdır.");

            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez.").MinimumLength(3).WithMessage("Şehir alanı minimum 3 karakterden oluşmalıdır.").MaximumLength(20).WithMessage("Şehir alanı maksimum 20 karakterden oluşmalıdır.");
        }
    }
}
