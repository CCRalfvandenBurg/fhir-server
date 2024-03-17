﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Health.Fhir.Core.Features.Operations.Import;

namespace Microsoft.Health.Fhir.Core.Features.Persistence
{
    public interface IFhirDataStore
    {
        Task<IReadOnlyList<string>> ImportResourcesAsync(IReadOnlyList<ImportResource> resources, ImportMode importMode, CancellationToken cancellationToken);

        Task<IDictionary<DataStoreOperationIdentifier, DataStoreOperationOutcome>> MergeAsync(IReadOnlyList<ResourceWrapperOperation> resources, CancellationToken cancellationToken);

        Task<IDictionary<DataStoreOperationIdentifier, DataStoreOperationOutcome>> MergeAsync(IReadOnlyList<ResourceWrapperOperation> resources, MergeOptions mergeOptions, CancellationToken cancellationToken);

        Task<IReadOnlyList<ResourceWrapper>> GetAsync(IReadOnlyList<ResourceKey> keys, CancellationToken cancellationToken);

        Task<UpsertOutcome> UpsertAsync(ResourceWrapperOperation resource, CancellationToken cancellationToken);

        Task<ResourceWrapper> GetAsync(ResourceKey key, CancellationToken cancellationToken);

        Task HardDeleteAsync(ResourceKey key, bool keepCurrentVersion, CancellationToken cancellationToken);

        Task BulkUpdateSearchParameterIndicesAsync(IReadOnlyCollection<ResourceWrapper> resources, CancellationToken cancellationToken);

        Task<ResourceWrapper> UpdateSearchParameterIndicesAsync(ResourceWrapper resourceWrapper, CancellationToken cancellationToken);

        Task<int?> GetProvisionedDataStoreCapacityAsync(CancellationToken cancellationToken);
    }
}
