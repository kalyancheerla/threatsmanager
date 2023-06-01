# MicroSvcsThreatsMapper
An extension tool for TMS app to generate threatmodels for microservices in OpenShift Kubernetes Clusters.

This is the library code for the extension MicroSvcsThreatsMapper.

## How to use:

### Video:

Below video contains the initial TMS setup, extension installation and it's usage with a sample micro services json dump.

https://github.com/kalyancheerla/threatsmanager/assets/32354220/3c7a52f0-bc10-448a-a2b8-40f10b9a0c25

### Some important steps from the recording,
* Change the TMS execution mode to `Pioneer`.
* Add the validation rule `MicroSvcsThreatsMapper` keyword for assembly must start with one of those prefixes.
* Disable the validation rule that assembly must be signed for one of those prefixes in the TMS app.
* Find the extension in the Import section and try using it with below `microsvcs.json` sample file.

### Sample microsvcs.json:
The contents of the below file can be described as a list projects with each project containing it's name and the list of nodes and each node contains it's name and list of pod names.

**File**: microsvcs.json
```
[
    {
        "name": "openshift-addon-operator",
        "nodes": [
            {
                "name": "ip-10-0-0-256.psp.external",
                "pods": [
                    "addon-operator-aaaaaaa-aaaaa",
                    "addon-operator-aaaaaaa-aaaaaaaaa-aaaaa",
                    "addon-operator-bbbbbbb-bbbbbbbbbb-bbbbb"
                ]
            },
            {
                "name": "ip-10-0-0-257.psp.external",
                "pods": [
                    "addon-operator-ccccccc-cccccccccc-ccccc"
                ]
            },
            {
                "name": "ip-10-0-0-258.psp.external",
                "pods": [
                    "addon-operator-ddddddd-dddddddddd-ddddd"
                ]
            }
        ]
    }
]
```

#### Thank you for reading through this, kindly reachout to us in here if you have any questions or further difficulties.
