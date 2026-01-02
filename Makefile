.PHONY: verify verify-slsa

verify:
	cosign verify ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest \
  --certificate-identity=https://github.com/ji-easv/PBSW-2025-secure-software-development-exam-project/.github/workflows/publish.yml@refs/heads/main \
  --certificate-oidc-issuer=https://token.actions.githubusercontent.com

verify-slsa:
	@docker pull ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest > /dev/null 2>&1 && \
    docker inspect --format='{{range .RepoDigests}}{{println .}}{{end}}' ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest | while read -r REPO_DIGEST; do \
        DIGEST=$$(echo $$REPO_DIGEST | cut -d'@' -f2) && \
        echo "Attempting verification with digest: $$DIGEST" && \
        slsa-verifier verify-image ghcr.io/ji-easv/pbsw-2025-secure-software-development-exam-project:latest@$$DIGEST \
        --source-uri github.com/ji-easv/PBSW-2025-secure-software-development-exam-project \
        --builder-id https://github.com/slsa-framework/slsa-github-generator/.github/workflows/generator_container_slsa3.yml@refs/tags/v2.1.0 \
        --print-provenance && break || echo "Failed with $$DIGEST, trying next..."; \
    done