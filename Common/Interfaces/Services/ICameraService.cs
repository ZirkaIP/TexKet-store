using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;

namespace Common.Interfaces.Services
{
	public interface ICameraService
	{
		Task<IEnumerable<Camera>> GetAllCamerasAsync();
		Task<Camera> GetCameraById(int id);
		Task<Camera> CreateCamera(Camera newCamera);
		Task UpdateCamera(Camera cameraToBeUpdated, Laptop camera);
		Task DeleteCamera(Camera camera);
	}
}
