using AutoMapper;
using FirstAPI.Exceptions;
using FirstAPI.Interfaces;
using FirstAPI.Migrations;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using FirstAPI.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace FirstAPI.Services
{
    public class AuthenticationService : IAuthenticate
    {
        IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, EmployeeStatusMaster> _employeeStatusMaster;
        private readonly IEmployeeService _employeeService;
        private readonly ITokenService _tokenService;
        private readonly IRepository<string, User> _userRepository;
        private readonly IMapper _mapper;
        IRepository<int, Department> _departmentRepository;
        public AuthenticationService(IRepository<int, Employee> employeeRepository,
        IRepository<int, Department> departmentRepository,
        IRepository<string,User> userRepository,
         IRepository<int, EmployeeStatusMaster> employeeStatusMaster,
         IEmployeeService employeeService,
         ITokenService tokenService,
        IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _employeeStatusMaster = employeeStatusMaster;
            _userRepository = userRepository;
            _employeeService = employeeService;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
           var dbUser = await _userRepository.GetById(loginRequest.Username);
            if (dbUser == null)
                throw new NoSuchEntityException();
            HMACSHA256 hmacsha256 = new HMACSHA256(dbUser.HashKey);
            var userPass = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));
            for (int i = 0; i < userPass.Length; i++)
            {
                if(userPass[i] != dbUser.Password[i])
                    throw new NoSuchEntityException();
            }
            return new LoginResponseDTO
            {
                Username = loginRequest.Username,
                Token = await _tokenService.GenerateToken(new TokenUser { Username=loginRequest.Username,Role=dbUser.Role })
            };
        }

        public async Task<AddEmployeeResponseDTO> RegisterEmployee(AddEmployeeRequestDTO employee)
        {
            try
            {
                var newEmployee = _mapper.Map<Employee>(employee);
                newEmployee = await _employeeService.AddEmployee(newEmployee);
                if (newEmployee != null)
                {
                    employee.Id = newEmployee.Id;
                    var user = PopulateUserObject(employee);
                    user.Role = "User";
                    user = await _userRepository.Add(user);

                    return new AddEmployeeResponseDTO { EmployeeId = newEmployee.Id };
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            throw new Exception("Unable to add user");
        }

        private User PopulateUserObject(AddEmployeeRequestDTO newEmployee)
        {
            User user = new User();
            user.Username = newEmployee.Username;
            user.EmployeeNumber = newEmployee.Id;
            HMACSHA256 hmacsha256 = new HMACSHA256();
            user.HashKey = hmacsha256.Key;
            var userPass = "#12" + user.Username + "@12";
            user.Password = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(userPass));
            return user;
        }
    }
}
