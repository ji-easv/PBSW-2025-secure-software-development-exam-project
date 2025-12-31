.PHONY: verify verify-slsa test

verify:
	cosign verify ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest \
  --certificate-identity=https://github.com/ji-easv/PBSW-2025-secure-software-development-exam-project/.github/workflows/publish.yml@refs/heads/main \
  --certificate-oidc-issuer=https://token.actions.githubusercontent.com

verify-slsa:
	cosign verify-attestation ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest \
	--type slsaprovenance \
  --certificate-oidc-issuer https://token.actions.githubusercontent.com \
  --certificate-identity-regexp '^https://github.com/slsa-framework/slsa-github-generator/.github/workflows/generator_container_slsa3.yml@refs/tags/v[0-9]+.[0-9]+.[0-9]+$$'

test:
	cosign verify-attestation ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest \
	--type slsaprovenance \
  --certificate-oidc-issuer https://token.actions.githubusercontent.com \
  --certificate-identity=https://github.com/ji-easv/PBSW-2025-secure-software-development-exam-project/.github/workflows/publish.yml@refs/heads/main \
