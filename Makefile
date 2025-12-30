.PHONY: verify

verify:
	cosign verify ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest \
  --certificate-identity=https://github.com/ji-easv/PBSW-2025-secure-software-development-exam-project/.github/workflows/publish.yml@refs/heads/main \
  --certificate-oidc-issuer=https://token.actions.githubusercontent.com