# 구글 애드몹 튜토리얼


### 1. 구글 애드몹 광고 아이디 발급

#### 구글 애드몹 가입 후 앱 추가
* 플랫폼 선택 (android / ios)
* 앱 이름 입력 (스토어에 등록되지 않아도 상관없음)
* 사용자 측정항목 (선택사항으로 추후 앱 설정에서 재설정 가능)

### 2. 광고 단위 추가
* 광고 형식 (배너 / 전면 / 보상형 전면 광고 / 리워드 등)
* 광고 단위 이름 입력후 광고 단위 추가
* 생성된 광고 단위의 광고 아이디 확인
* 실제 출시할 앱이 아니라면 이 과정을 생략하고 [샘플 광고 아이디](https://developers.google.com/admob/android/test-ads?hl=ko, "테스트 광고 사용 설정")를 입력

### 3. 구글 애드몹 유니티 플러그인 추가
* [googleads-mobile-unity](https://github.com/googleads/googleads-mobile-unity/releases, "googleads-mobile-unity github")에서 최신 버전의 유니티 패키지 다운로드
* 유니티 프로젝트에 패키지 임포트
* 경우에 따라서 resolving android dependencies가 실행되어 플러그인에 필요한 요소들을 프로젝트를 설치해줌
  * Android Resolver > Force Resolve로도 실행 가능
  * resolving android dependencies는 다음과 같은 경우로 인해 정상적으로 동작하지 않을 수 있음
  * android SDK & JDK 버전 및 미설치, 금융 사이트등에서의 보안프로그램 실행으로 인해
  * 폴더 경로에 더블 바이트 문자가 포함되어 있을 경우 (ExecutionEngineException: String conversion error: Illegal byte sequence encounted in the input.)

### 4. 빌드
* 안드로이드 빌드
  * Development Build 설정
  * 디바이스에서 실행시 크래쉬 발생 해결
   * 1. JAVA_HOME 환경변수 경로 재설정
   * 2. GoogleMobileAdsSettings > GoogleAdMob Enabled 를 true 로 설정하고 AdMob App ID(android) 추가
   * 3. AdMob App ID(iOS) 추가 및 테스트 디바이스 아이디 설정, 스크립트의 테스트 광고 아이디 대신 테스트 디바이스 아이디가 설정된 부분 수정
   * 4. AdMob App ID를 올바른 유효한 값으로 재설정 (구글 애드몹에서 추가한 앱의 ID가 아닌 샘플 광고 아이디를 설정해주어 발생한 문제...) -> 앱 실행 후 정상 동작 확인
