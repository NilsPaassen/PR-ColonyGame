//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/Actions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Actions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""151ad4f9-c422-4b61-a19b-af5d780ab18b"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""d54ef798-81fc-4890-a64d-31c4b0dc60a4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c042b9df-a0e7-4a31-825e-f0e00e378fc9"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Build Mode"",
                    ""type"": ""Button"",
                    ""id"": ""0ebb5e40-dd80-4996-b777-eeaaf01848ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""bfe0fec8-6143-4550-ad65-8bc234185aac"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DestroyBuilding"",
                    ""type"": ""Button"",
                    ""id"": ""593384a8-965f-440b-8a91-7cc78297c4e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f01befe-0400-4d04-b163-b81039060c8c"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Page Up/Down"",
                    ""id"": ""84600837-f225-48ec-b5f6-c6325874d1df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3d4af5ab-62e0-4e83-854c-1f85eaf7844f"",
                    ""path"": ""<Keyboard>/pageDown"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a75fce2b-156f-4412-acac-92f3e3886ad8"",
                    ""path"": ""<Keyboard>/pageUp"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""+-"",
                    ""id"": ""b293732c-7bf4-40cd-8fdb-d0df2698c206"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""2c48bf79-0054-4133-aac2-cfaf9e617c8f"",
                    ""path"": ""<Keyboard>/#(-)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""ba77810b-eb91-4a93-9005-390390bd7445"",
                    ""path"": ""<Keyboard>/#(+)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Numpad +-"",
                    ""id"": ""673268da-f22f-4013-bc6d-c17cbf75d67e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dbb25edf-3517-44af-8116-2af22082fc54"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c6988143-90b0-4131-91f6-9e85649d4ffe"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""dd2c6b6b-2506-4b33-85e2-e6a3b06733a4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c0fc81db-191e-4494-9919-cfdf078c2877"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""039459de-4ef6-4a8d-b325-0f1d76db557b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f8ccadc9-0fd9-4864-b862-4a38b1f53a6d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9cd22b82-3c23-4525-8e1a-df806d5ba012"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""ab2fb55a-349d-4779-b170-08517ccd5cf9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8a8eeab4-5c72-49a4-a168-c33edc8b85da"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ce590428-a7b8-43ff-80d4-8e227ed4db01"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02f91fc3-5e30-46ce-a92f-26e792faeaa2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eeb1ff51-cc0f-4e1d-a6b1-a6a99432fe78"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""a8700e96-a2f0-465d-b59b-87a6591d3675"",
                    ""path"": ""OneModifierVector2(normalize=false,mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""Mouse(wholeScreenValue=1.25,macOsFactor=5)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5cf724b9-5711-4fe7-91da-d981ff9ad1d5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""25046a60-466b-4ca6-bf02-a80be0707369"",
                    ""path"": ""<Mouse>/delta/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f1b43fdd-17c7-48e4-8847-8d1c2a251ee0"",
                    ""path"": ""<Mouse>/delta/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""440fc6a1-41bb-41d1-a214-f390d00fd730"",
                    ""path"": ""<Mouse>/delta/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b409ba5c-42ff-4a2e-91e5-f6096b93049f"",
                    ""path"": ""<Mouse>/delta/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Screen Edge"",
                    ""id"": ""7c100123-ee5a-4dd3-b87b-be924a87f790"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""56314ed0-65fc-4327-82ab-4f94215f94b5"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": ""ScreenEdge(distance=20)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""132c81ff-fc75-4ddb-a4b9-a9f3e0c45a88"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": ""ScreenEdge(screenEdge=1,distance=20)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d97b1686-140f-4d0a-b62c-ea8e20d0a73e"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": ""ScreenEdge(screenEdge=2,distance=20)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3356e390-396b-4a5a-8571-d1c80ae0e106"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": ""ScreenEdge(screenEdge=3,distance=20)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""2a4c0404-603a-4a47-9a09-4918636870b3"",
                    ""path"": ""OneModifierVector2(normalize=false,mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""Mouse(wholeScreenValue=1.25,macOsFactor=5)"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5a557908-ca7a-496b-a264-62368b74c7e5"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""af282f2e-49b2-4119-bc16-4b9da4afd53b"",
                    ""path"": ""<Mouse>/delta/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""67b0a75a-ca99-4b10-b1fc-d58704d3027e"",
                    ""path"": ""<Mouse>/delta/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""06022cd4-6e53-4d60-b828-5eeb40b56342"",
                    ""path"": ""<Mouse>/delta/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b913b1d7-146f-421c-9e1b-ae5d6f11a92d"",
                    ""path"": ""<Mouse>/delta/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""QE"",
                    ""id"": ""7036b289-6f14-44d0-a920-c114a816114f"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f1429df9-0212-4a77-9106-048094453445"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""255681de-fcd5-4982-acd7-81916d8e3bb4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""93073482-5169-4a4d-b746-e3b08b542bf1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""773e1ef3-b5a7-432c-88f4-74f29cacf32f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ZX"",
                    ""id"": ""ff81d920-ad26-483a-bacf-00af3c84da84"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2db37e2e-9a02-4e28-8902-f72b98f3c1dc"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""83298869-6f63-4d91-8b54-20c37e9e5486"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3cb64af6-ffec-48a5-92a1-425e739916b9"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""429ce396-2e47-44b2-80ad-ec923d9e7dd9"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": "",."",
                    ""id"": ""640ba92e-24dc-4c35-95f2-820b689a41a3"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""10290932-9c9f-41db-8b34-a79de9d77c58"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""248e0bbf-c515-442f-ae96-617ecf4297e7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b1866342-c20c-4364-bd5b-619b25cadee3"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""796f2b83-cc5b-498a-be43-2b4b4dc4bfe7"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1061c4ac-c05e-45e1-8341-32c00dba6ef6"",
                    ""path"": ""<Keyboard>/#(B)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c9ab88d-7acd-4cac-b2fc-eef1cf94c976"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DestroyBuilding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Build Mode"",
            ""id"": ""11bcd613-3af2-42ff-80b4-af2811878114"",
            ""actions"": [
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Value"",
                    ""id"": ""f3063794-c3f5-4d4a-ac84-49f820e48948"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""f01fee13-f65f-4942-9a86-223e7df2e7db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Place"",
                    ""type"": ""Button"",
                    ""id"": ""830f68dd-1b7c-4138-b327-a691318acf3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a7aa5400-81da-4ed7-8fe6-ab8e443f62fb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""059ef156-0200-4fc0-a83e-6d771b0f8f4c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef68a01b-cfe9-44e1-9317-ffe4fcac3861"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Zoom = m_Player.FindAction("Zoom", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_BuildMode = m_Player.FindAction("Build Mode", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_DestroyBuilding = m_Player.FindAction("DestroyBuilding", throwIfNotFound: true);
        // Build Mode
        m_BuildMode = asset.FindActionMap("Build Mode", throwIfNotFound: true);
        m_BuildMode_Cursor = m_BuildMode.FindAction("Cursor", throwIfNotFound: true);
        m_BuildMode_Rotate = m_BuildMode.FindAction("Rotate", throwIfNotFound: true);
        m_BuildMode_Place = m_BuildMode.FindAction("Place", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Zoom;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_BuildMode;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_DestroyBuilding;
    public struct PlayerActions
    {
        private @Actions m_Wrapper;
        public PlayerActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_Player_Zoom;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @BuildMode => m_Wrapper.m_Player_BuildMode;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @DestroyBuilding => m_Wrapper.m_Player_DestroyBuilding;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Zoom.started += instance.OnZoom;
            @Zoom.performed += instance.OnZoom;
            @Zoom.canceled += instance.OnZoom;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @BuildMode.started += instance.OnBuildMode;
            @BuildMode.performed += instance.OnBuildMode;
            @BuildMode.canceled += instance.OnBuildMode;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @DestroyBuilding.started += instance.OnDestroyBuilding;
            @DestroyBuilding.performed += instance.OnDestroyBuilding;
            @DestroyBuilding.canceled += instance.OnDestroyBuilding;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Zoom.started -= instance.OnZoom;
            @Zoom.performed -= instance.OnZoom;
            @Zoom.canceled -= instance.OnZoom;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @BuildMode.started -= instance.OnBuildMode;
            @BuildMode.performed -= instance.OnBuildMode;
            @BuildMode.canceled -= instance.OnBuildMode;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @DestroyBuilding.started -= instance.OnDestroyBuilding;
            @DestroyBuilding.performed -= instance.OnDestroyBuilding;
            @DestroyBuilding.canceled -= instance.OnDestroyBuilding;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Build Mode
    private readonly InputActionMap m_BuildMode;
    private List<IBuildModeActions> m_BuildModeActionsCallbackInterfaces = new List<IBuildModeActions>();
    private readonly InputAction m_BuildMode_Cursor;
    private readonly InputAction m_BuildMode_Rotate;
    private readonly InputAction m_BuildMode_Place;
    public struct BuildModeActions
    {
        private @Actions m_Wrapper;
        public BuildModeActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cursor => m_Wrapper.m_BuildMode_Cursor;
        public InputAction @Rotate => m_Wrapper.m_BuildMode_Rotate;
        public InputAction @Place => m_Wrapper.m_BuildMode_Place;
        public InputActionMap Get() { return m_Wrapper.m_BuildMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BuildModeActions set) { return set.Get(); }
        public void AddCallbacks(IBuildModeActions instance)
        {
            if (instance == null || m_Wrapper.m_BuildModeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BuildModeActionsCallbackInterfaces.Add(instance);
            @Cursor.started += instance.OnCursor;
            @Cursor.performed += instance.OnCursor;
            @Cursor.canceled += instance.OnCursor;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Place.started += instance.OnPlace;
            @Place.performed += instance.OnPlace;
            @Place.canceled += instance.OnPlace;
        }

        private void UnregisterCallbacks(IBuildModeActions instance)
        {
            @Cursor.started -= instance.OnCursor;
            @Cursor.performed -= instance.OnCursor;
            @Cursor.canceled -= instance.OnCursor;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Place.started -= instance.OnPlace;
            @Place.performed -= instance.OnPlace;
            @Place.canceled -= instance.OnPlace;
        }

        public void RemoveCallbacks(IBuildModeActions instance)
        {
            if (m_Wrapper.m_BuildModeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBuildModeActions instance)
        {
            foreach (var item in m_Wrapper.m_BuildModeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BuildModeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BuildModeActions @BuildMode => new BuildModeActions(this);
    public interface IPlayerActions
    {
        void OnZoom(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnBuildMode(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnDestroyBuilding(InputAction.CallbackContext context);
    }
    public interface IBuildModeActions
    {
        void OnCursor(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnPlace(InputAction.CallbackContext context);
    }
}
