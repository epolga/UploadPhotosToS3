# UploadPhotosToS3

UploadPhotosToS3 is a C# application that uploads a structured photo collection (albums and designs) from a local directory to an Amazon S3 bucket. Paired with an Angular frontend, it enables public viewing of the images via direct S3 URLs. Ideal for managing and showcasing photo galleries with a simple, scalable cloud solution.

## Features
- Uploads photos from a local directory (`D:\ftproot\photos`) to an S3 bucket.
- Supports a nested folder structure: `albums/designs/photos` (e.g., `6/31/1.jpg`).
- Publicly accessible images via S3 URLs for display in an Angular web app.
- Built with .NET (C#) and the AWS SDK for S3 integration.

## Prerequisites
- **AWS Account**: An S3 bucket with public read access configured.
- **.NET SDK**: For running the C# uploader (e.g., .NET 6 or later).
- **Node.js**: For the Angular frontend (if included).
- **Git**: To clone and manage this repository.

## Setup

### 1. Clone the Repository
```bash
git clone https://github.com/<your-username>/UploadPhotosToS3.git
cd UploadPhotosToS3
