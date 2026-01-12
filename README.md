# Azure Order Management System (OMS)

![Azure](https://img.shields.io/badge/Azure-App%20Service-blue?logo=microsoftazure)
![.NET](https://img.shields.io/badge/.NET-8.0-purple?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Programming-blueviolet?logo=csharp)
![Build](https://img.shields.io/badge/Build-Passing-brightgreen)
![License](https://img.shields.io/badge/License-MIT-green)

🚀 A **cloud-native Order Management System** built with **ASP.NET Core (.NET 8)** and deployed on **Azure App Service**, following **Clean Architecture** and modern Azure security best practices.

---

## 🔑 Key Highlights

- **ASP.NET Core (.NET 8) Web API**
- Deployed on **Azure App Service**
- **Azure Key Vault** for secure secrets management
- **Managed Identity** (no secrets stored in code or config)
- **JWT Authentication**
- **Entity Framework Core + SQL Server**
- **Clean Architecture** (Domain, Application, Infrastructure, API)
- **Swagger / OpenAPI** enabled

---

## 🏗️ Architecture

The solution follows **Clean Architecture**, ensuring separation of concerns and maintainability:

Domain → Application → Infrastructure → API

Each layer has a clear responsibility and is independently testable.

---

## 🔐 Security & Configuration

- Secrets stored securely in **Azure Key Vault**
- Access via **Managed Identity**
- Configuration bound and cached at startup using **Options Pattern**
- No sensitive data committed to source control

---

## ☁️ Azure Practices Demonstrated

- Secure cloud configuration
- Real-world debugging of ASP.NET Core startup issues (**500.30 / 500.37**)
- Proper Azure identity & access management
- Cost optimization by stopping App Service and using serverless SQL (auto-pause)
- Git hygiene (`bin/obj` excluded, secrets ignored)

---

## 🧪 API Documentation

Swagger UI is enabled for API exploration:

/swagger/index.html

---

## 🎯 Purpose of This Project

This project demonstrates **real-world Azure deployment, security, and configuration patterns** for modern .NET backend applications and serves as a **portfolio project** showcasing Azure and ASP.NET Core expertise.

---

## 🙌 Feedback

Feedback and suggestions are welcome.  
This project was built as part of hands-on learning with **Azure and .NET**.