# Secure Softare Development Exam Project

This is a project developed for the 2nd semester of the Software Development Top-Up education at EASV.

## Run

Running with Docker Compose

```sh
docker compose up
```

This will start:

- Backend API on http://localhost:5021
- PostgreSQL database on localhost:5432

Running Frontend Locally

```sh
cd frontend
npm ci
npm run dev
```

Frontend will be available at http://localhost:5173

Running Backend Locally

```sh
cd SSD-Exam-Project
dotnet run
```

## Supply Chain Security

The project includes various security checks via [security-checks.yml](.github/workflows/security-checks.yml):

1. Dependency Review: Scans for vulnerable dependencies on pull requests
2. Snyk Integration:
   - SAST (Static Application Security Testing) with Snyk Code
   - SCA (Software Composition Analysis) with Snyk Open Source
   - Container scanning for Docker images
   - Results uploaded to GitHub Security tab

## Publish Action

Implemented in [publish.yml](.github/workflows/publish.yml):

1. Image Signing: Docker images signed with Cosign
2. SLSA Provenance: Level 3 provenance attestation
3. SBOM Generation: Software Bill of Materials using CycloneDX
4. Verification: Automated SLSA provenance verification
5. Verify Published Images

Verify signature:

```sh
make verify
```

Verify SLSA provenance:

```sh
make verify-slsa
```
