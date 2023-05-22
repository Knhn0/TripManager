using Microsoft.AspNetCore.Mvc;
using TripManager.Models;
using TripManager.Service.Interfaces;

namespace TripManager.Controllers
{

    [Route("userservice")]
    public class UserController : Controller
    {
        private readonly IUserLogic userLogic;

        public UserController(IUserLogic logic)
        {
            userLogic = logic;
        }

        // testing
        static List<UserRegister> usersList = new List<UserRegister>() { new UserRegister() { Email = "string1", Password = "string1" } };

        /// <summary>
        /// Регистрация пользователя в системе.
        /// </summary>
        /// <param name="request">Содержит информацию о пользователе. Обязательные поля: ФИО, почта, пароль, тип пользователя.</param>
        /// <response code="200">Успех, пользователь зарегестрирован.</response>
        /// <response code="400">Ошибка. Не удалось зарегестрировать пользователя, полученные данные не верны.</response>
        /// <response code="500">Внутренняя ошибка.</response>
        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] UserRegister request)
        {
            if (request == null
                || request.Surname == null
                || request.Name == null
                || request.Patronymic == null
                || request.Email == null
                || request.Password == null
                || request.UserType == null)
            {
                return BadRequest();
            }

            return Ok(userLogic.Register(new Service.Models.User
            {
                Surname = request.Surname,
                Name = request.Name,
                Patronymic = request.Patronymic,
                Password = request.Password,
                Email = request.Email,
                UserType = request.UserType,
                Phone = request.Phone,
            }));
        }

        /// <summary>
        /// Войти в систему под определенным пользователем.
        /// </summary>
        /// <param name="loginData">Данные для входа: почта, пароль.</param>
        /// <returns>access_token, username</returns>
        /// <response code="200">Успех.</response>
        /// <response code="400">Указанные данные не верны.</response>
        /// <response code="401">Ошибка. Войти под указанными данными не удалось.</response>
        /// <response code="500">Внутренняя ошибка.</response>
        [Route("login")]
        [HttpPost]
        public JsonResult Login([FromBody] LoginUser loginData)
        {
            if (loginData == null
                || loginData.Email == null
                || loginData.Password == null)
            {
                return Json(BadRequest());
            }

            var response = userLogic.Auth(new Service.Models.User
                { Email = loginData.Email, Password = loginData.Password });

            return response == null ? Json(StatusCode(500)) : Json(response);
        }
    }
}